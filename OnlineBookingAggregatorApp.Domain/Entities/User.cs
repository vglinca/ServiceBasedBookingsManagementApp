using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? OnHolidayFrom { get; set; }
        public DateTimeOffset? OnHolidayTo { get; set; }
        public DateTimeOffset? FiredAt { get; set; }
        public string Specialization { get; set; }
        public string Information { get; set; }
        public Company Company { get; set; }
        public long? CompanyId { get; set; }
        public long? PositionId { get; set; }
        public Position Position { get; set; }
        public Gender? Gender { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public SystemRole SystemRole { get; private set; }
        public string RefreshToken { get; set; }
        public ICollection<ServiceEmployee> ServiceEmployees { get; set; } = new List<ServiceEmployee>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public User()
        {
            CreatedAt = DateTimeOffset.Now;
        }

        public void AssociateWithRole(SystemRole role)
        {
            SystemRole = role;
        }
    }
}