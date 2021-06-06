using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using Xunit;

namespace OnlineBookingAggregatorApp.UnitTests.Infrastructure.Validators
{
    public class EmployeeCreateUpdateValidatorTests
    {
        private readonly EmployeeCreateUpdateDtoValidator _sut = new();

        private readonly EmployeeCreateUpdateDto _validDto = new()
        {
            FirstName = "Patryk",
            LastName = "Rose",
            Email = "patryk.rose@email.com",
            Gender = Gender.Male,
            Phone = "123456789",
            Specialization = "Specialization",
            Information = "Info",
            Status = EmployeeStatus.Active,
            RoleId = SystemRole.Specialist,
            WorkSchedules = new List<WorkScheduleDto>()
            {
                new()
                {
                    DaysOfWeek = new List<WeekDay>()
                    {
                        WeekDay.Monday
                    },
                    WorkingHoursFrom = 8,
                    WorkingMinutesFrom = 0,
                    WorkingHoursTo = 15,
                    WorkingMinutesTo = 0
                }
            }
        };

        [Fact]
        public void WithAValidDto()
        {
            var dto = _validDto;
            var result = _sut.Validate(dto);
            Assert.Equal(0, result.Errors.Count);
        }

        [Fact]
        public void WithAValidaDtoWithEmptyFirstNameLastName()
        {
            var dto = _validDto;
            dto.FirstName = string.Empty;
            dto.LastName = string.Empty;
            var result = _sut.Validate(dto);
            Assert.Equal(2, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithEmptyEmail()
        {
            var dto = _validDto;
            dto.Email = string.Empty;
            var result = _sut.Validate(dto);
            Assert.Equal(2, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithEmptyWorkSchedules()
        {
            var dto = _validDto;
            dto.WorkSchedules = new List<WorkScheduleDto>();
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }
    }
}