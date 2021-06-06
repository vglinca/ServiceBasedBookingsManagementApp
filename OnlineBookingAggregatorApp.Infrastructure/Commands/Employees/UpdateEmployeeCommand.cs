using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Employees
{
    public class UpdateEmployeeCommand : Command<(long, EmployeeCreateUpdateDto)>
    {
        private readonly UserManager<User> _employees;
        private readonly AppDbContext _dbContext;

        public UpdateEmployeeCommand(UserManager<User> employees, AppDbContext dbContext)
        {
            _employees = employees;
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, EmployeeCreateUpdateDto) input)
        {
            var (employeeId, dto) = input;

            var employee = await _employees.FindByIdAsync(employeeId.ToString());
            if (employee == null)
            {
                throw EntityNotFoundException.OfType<User>();
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Gender = dto.Gender;
            employee.PhoneNumber = dto.Phone;
            employee.PositionId = dto.PositionId;
            employee.Specialization = dto.Specialization;
            employee.Information = dto.Information;
            employee.AssociateWithRole(dto.RoleId);

            var result = await _employees.UpdateAsync(employee);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Could not update employee.");
            }
    
            await ProcessWorkSchedules(employeeId, dto);
        }

        private async Task ProcessWorkSchedules(long employeeId, EmployeeCreateUpdateDto dto)
        {
            var employeeWorkSchedules = await _dbContext.WorkSchedules
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();

            foreach (var workScheduleDto in dto.WorkSchedules.Where(x => x.WorkScheduleId == 0))
            {
                await AddNewWorkSchedules(workScheduleDto, workScheduleDto.DaysOfWeek, employeeId);
            }

            var workSchedulesToRemove = employeeWorkSchedules
                .Where(x => !dto.WorkSchedules
                    .Select(y => y.WorkScheduleId).Contains(x.Id))
                .ToList();
            
            _dbContext.WorkSchedules.RemoveRange(workSchedulesToRemove);

            var workSchedulesToUpdate = employeeWorkSchedules
                .Where(x => dto.WorkSchedules
                    .Select(y => y.WorkScheduleId).Contains(x.Id))
                .ToList();
            
            foreach (var workScheduleDto in dto.WorkSchedules.Where(x => x.WorkScheduleId > 0))
            {
                await UpdateWorkSchedule(workSchedulesToUpdate, workScheduleDto);
            }
        }

        private async Task UpdateWorkSchedule(List<WorkSchedule> workSchedulesToUpdate, WorkScheduleDto workScheduleDto)
        {
            var workScheduleToAmend = workSchedulesToUpdate.FirstOrDefault(x => x.Id == workScheduleDto.WorkScheduleId);

            if (workScheduleToAmend == null)
            {
                return;
            }

            workScheduleToAmend.WorkingHoursFrom = workScheduleDto.WorkingHoursFrom;
            workScheduleToAmend.WorkingMinutesFrom = workScheduleDto.WorkingMinutesFrom;
            workScheduleToAmend.WorkingHoursTo = workScheduleDto.WorkingHoursTo;
            workScheduleToAmend.WorkingMinutesTo = workScheduleDto.WorkingMinutesTo;

            await ProcessScheduleWeekDays(workScheduleToAmend, workScheduleDto);
        }

        private async Task ProcessScheduleWeekDays(WorkSchedule workScheduleToAmend, WorkScheduleDto workScheduleDto)
        {
            var scheduleWeekDays = await _dbContext.WeekDayWorkSchedules
                .Where(x => x.WorkScheduleId == workScheduleToAmend.Id)
                .ToListAsync();

            var scheduleWeekDaysToRemove = scheduleWeekDays
                .Where(x => !workScheduleDto.DaysOfWeek.Contains(x.DayOfWeek));

            _dbContext.WeekDayWorkSchedules.RemoveRange(scheduleWeekDaysToRemove);

            var scheduleWeekDaysToAdd = workScheduleDto.DaysOfWeek
                .Where(x => !scheduleWeekDays.Select(y => y.DayOfWeek).Contains(x))
                .Select(x => new WeekDayWorkSchedule
                {
                    WorkSchedule = workScheduleToAmend,
                    DayOfWeek = x
                });

            await _dbContext.WeekDayWorkSchedules.AddRangeAsync(scheduleWeekDaysToAdd);
        }

        private async Task AddNewWorkSchedules(WorkScheduleDto dto, IEnumerable<WeekDay> weekDays, long employeeId)
        {
            var workSchedule = new WorkSchedule
            {
                WorkingHoursFrom = dto.WorkingHoursFrom,
                WorkingHoursTo = dto.WorkingHoursTo,
                WorkingMinutesFrom = dto.WorkingMinutesFrom,
                WorkingMinutesTo = dto.WorkingMinutesTo,
                EmployeeId = employeeId
            };
            
            var weekDayWorkSchedules = weekDays.Distinct()
                .Select(x => new WeekDayWorkSchedule
                {
                    WorkSchedule = workSchedule,
                    DayOfWeek = x
                });
            
            await _dbContext.WorkSchedules.AddAsync(workSchedule);
            await _dbContext.WeekDayWorkSchedules.AddRangeAsync(weekDayWorkSchedules);
        }
    }
}