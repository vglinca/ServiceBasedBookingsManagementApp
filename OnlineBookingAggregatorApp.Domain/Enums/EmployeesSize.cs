using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum EmployeesSize
    {
        One = 1,
        FromTwoToFive,
        FromSixToTen,
        FromElevenToTwenty,
        TwentyOnePlus
    }

    public class EmployeesSizeEntity : EnumEntity<EmployeesSize>
    {
        public EmployeesSizeEntity() { }
        public EmployeesSizeEntity(EmployeesSize id, string name) : base(id, name) { }
    }

    public class EmployeesSizeEntityFactory : EnumEntityFactory<EmployeesSize, EmployeesSizeEntity>
    {
        public static EmployeesSizeEntityFactory Instance { get; } = new EmployeesSizeEntityFactory();

        public EmployeesSizeEntityFactory()
        {
            Register(
                    new EmployeesSizeEntity(EmployeesSize.One, "1"),
                    new EmployeesSizeEntity(EmployeesSize.FromTwoToFive, "2-5"),
                    new EmployeesSizeEntity(EmployeesSize.FromSixToTen, "6-10"),
                    new EmployeesSizeEntity(EmployeesSize.FromElevenToTwenty, "11-20"),
                    new EmployeesSizeEntity(EmployeesSize.TwentyOnePlus, "21+")
                );
        }
    }
}