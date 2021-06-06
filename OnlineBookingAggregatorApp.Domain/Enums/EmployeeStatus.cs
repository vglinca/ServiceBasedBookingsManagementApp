using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum EmployeeStatus
    {
        Active = 1,
        OnHoliday,
        Hidden,
        Fired
    }

    public class EmployeeStatusEntity : EnumEntity<EmployeeStatus>
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public EmployeeStatusEntity() { }

        public EmployeeStatusEntity(EmployeeStatus id, string name, string description, string icon) : base(id, name)
        {
            Description = description;
            Icon = icon;
        }
    }

    public class EmployeeStatusEntityFactory : EnumEntityFactory<EmployeeStatus, EmployeeStatusEntity>
    {
        public static EmployeeStatusEntityFactory Instance { get; } = new EmployeeStatusEntityFactory();

        public EmployeeStatusEntityFactory()
        {
            Register(
                new EmployeeStatusEntity(EmployeeStatus.Active, "Active", "An employee is currently active.", "person"),
                new EmployeeStatusEntity(EmployeeStatus.OnHoliday, "On Holiday", "An employee is currently on holiday.", "logout"),
                new EmployeeStatusEntity(EmployeeStatus.Hidden, "Hidden", "An employee is hidden for some reason.", "person_outline"),
                new EmployeeStatusEntity(EmployeeStatus.Fired, "Fired", "An employee is fired, but not removed from the system.", "person_off"));
        }
    }
}