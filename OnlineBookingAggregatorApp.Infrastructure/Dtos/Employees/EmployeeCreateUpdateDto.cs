using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees
{
    public class EmployeeCreateUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public string Phone { get; set; }
        public long? PositionId { get; set; }
        public string Specialization { get; set; }
        public string Information { get; set; }
        public EmployeeStatus Status { get; set; }
        public SystemRole RoleId { get; set; }
        public IList<WorkScheduleDto> WorkSchedules { get; set; } = new List<WorkScheduleDto>();
        public static User To(EmployeeCreateUpdateDto src) => new()
        {
            FirstName = src.FirstName,
            LastName = src.LastName,
            Email = src.Email,
            Gender = src.Gender,
            PhoneNumber = src.Phone,
            PositionId = src.PositionId,
            Specialization = src.Specialization,
            Information = src.Information,
            EmployeeStatus = src.Status
        };
    }
}