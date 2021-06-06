using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Infrastructure.Utils;
using OnlineBookingAggregatorApp.Persistence.Data;

// ReSharper disable All


namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Employees
{
    public class AddEmployeeCommand : Command<(long, EmployeeCreateUpdateDto), long>
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly HttpContext _httpContext;
        private readonly AppDbContext _dbContext;

        public AddEmployeeCommand(
            IEmailService emailService, 
            IHttpContextAccessor accessor, UserManager<User> userManager, AppDbContext dbContext)
        {
            _emailService = emailService;
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContext = accessor.HttpContext;
        }

        public override async Task<long> ExecuteAsync((long, EmployeeCreateUpdateDto) input)
        {
            var (companyId, employeeDto) = input;
            var employee = EmployeeCreateUpdateDto.To(employeeDto);
            employee.EmployeeStatus = EmployeeStatus.Active;
            employee.CompanyId = companyId;
            
            var password = RandomStringGenerator.GenerateRandomString(12);
            employee.UserName = RandomStringGenerator.GenerateRandomString(10);
            employee.AssociateWithRole(employeeDto.RoleId);
            var result = await _userManager.CreateAsync(employee, password);
            if (result.Succeeded)
            {
                var emailContent = $"<!DOCTYPE html><body><p>Your password is: <a>{password}</a></p></body>";
                await _emailService.SendEmailAsync(employeeDto.Email, "Account Password", emailContent);
                await _userManager.AddToRoleAsync(employee, nameof(SystemRole.Specialist));

                await AddWorkSchedules(employeeDto, employee);

                return employee.Id;
            }
           
            throw new BadRequestException("Could not add an employee.");
        }

        private async Task AddWorkSchedules(EmployeeCreateUpdateDto employeeDto, User employee)
        {
            var workSchedules = new List<WorkSchedule>();

            foreach (var workSchedule in employeeDto.WorkSchedules)
            {
                var schedule = new WorkSchedule
                {
                    Employee = employee,
                    WorkingHoursFrom = workSchedule.WorkingHoursFrom,
                    WorkingMinutesFrom = workSchedule.WorkingMinutesFrom,
                    WorkingHoursTo = workSchedule.WorkingHoursTo,
                    WorkingMinutesTo = workSchedule.WorkingMinutesTo
                };

                var weekDayWorkSchedules = AddScheduleForEachWeekDay(workSchedule, schedule);
                await _dbContext.WorkSchedules.AddAsync(schedule);
                await _dbContext.WeekDayWorkSchedules.AddRangeAsync(weekDayWorkSchedules);
            }
        }

        private static List<WeekDayWorkSchedule> AddScheduleForEachWeekDay(WorkScheduleDto workSchedule, WorkSchedule schedule)
        {
            var weekDayWorkSchedules = new List<WeekDayWorkSchedule>();
            foreach (var dayOfWeek in workSchedule.DaysOfWeek)
            {
                weekDayWorkSchedules.Add(new WeekDayWorkSchedule
                {
                    WorkSchedule = schedule,
                    DayOfWeek = dayOfWeek
                });
            }

            return weekDayWorkSchedules;
        }
    }
}