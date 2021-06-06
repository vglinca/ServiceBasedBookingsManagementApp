using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
// ReSharper disable All

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long? CompanyId { get; set; }
        public Gender? Gender { get; set; }
        public long? PositionId { get; set; }
        public string Position { get; set; }
        public string Information { get; set; }
        public string Specialization { get; set; }
        public DateTimeOffset? OnHolidayFrom { get; set; }
        public DateTimeOffset? OnHolidayTo { get; set; }
        public DateTimeOffset? FiredAt { get; set; }
        public EmployeeStatus Status { get; set; }
        public SystemRole RoleId { get; set; }
        public string SystemRole { get; set; }

        public static EmployeeDto From(User src) => new()
        {
            Id = src.Id,
            FirstName = src.FirstName,
            LastName = src.LastName,
            Email = src.Email,
            PhoneNumber = src.PhoneNumber,
            CompanyId = src.CompanyId,
            Gender = src.Gender,
            PositionId = src.PositionId,
            Position = src.Position?.Name,
            Information = src.Information,
            Specialization = src.Specialization,
            OnHolidayFrom = src.OnHolidayFrom,
            OnHolidayTo = src.OnHolidayTo,
            FiredAt = src.FiredAt,
            Status = src.EmployeeStatus,
            RoleId = src.SystemRole,
            SystemRole = Enum.GetName(typeof(SystemRole), src.SystemRole)
        };
    }
}