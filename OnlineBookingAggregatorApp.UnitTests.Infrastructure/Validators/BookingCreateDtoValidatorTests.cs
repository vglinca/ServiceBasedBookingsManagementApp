using System;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using Xunit;

namespace OnlineBookingAggregatorApp.UnitTests.Infrastructure.Validators
{
    public class BookingCreateDtoValidatorTests
    {
        private readonly BookingCreateDtoValidator _sut = new();

        private readonly BookingCreateDto _validDto = new()
        {
            ClientId = 1,
            ServiceId = 1,
            DateFrom = DateTime.Now.AddDays(1),
            DateTo = DateTime.Now.AddDays(1),
            HourFrom = 9,
            MinutesFrom = 30,
            HourTo = 10,
            MinutesTo = 45,
            Colour = null,
            Comments = "Comments",
            SpecialistId = 1,
            ClientFirstName = string.Empty,
            ClientLastName = string.Empty,
            ClientEmail = string.Empty,
            ClientPhone = string.Empty
        };

        [Fact]
        public void WithAValidDto()
        {
            var dto = _validDto;
            var result = _sut.Validate(dto);
            Assert.Equal(0, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithDateToLessThanDateFrom()
        {
            var dto = _validDto;
            dto.DateTo = DateTime.Now.AddDays(-1);
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithHourToLessThanHourFrom()
        {
            var dto = _validDto;
            dto.HourTo = dto.HourFrom - 1;
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithEqualHoursAndMinutesToNotGreaterThanMinutesFrom()
        {
            var dto = _validDto;
            dto.HourTo = dto.HourFrom;
            dto.MinutesTo = dto.MinutesFrom;
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithZeroClientIdAndNullClientInfo()
        {
            var dto = _validDto;
            dto.ClientId = 0;
            var result = _sut.Validate(dto);
            Assert.Equal(5, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithNotEmptyClientInfo()
        {
            var dto = _validDto;
            dto.ClientId = 0;
            dto.ClientFirstName = "Nick";
            dto.ClientLastName = "Chan";
            dto.ClientEmail = "nc@email.com";
            dto.ClientPhone = "+3437438973837";
            
            var result = _sut.Validate(dto);
            Assert.Equal(0, result.Errors.Count);
        }
        
        [Fact]
        public void WithAValidDtoWithNotEmptyClientInfoAndInvalidEmail()
        {
            var dto = _validDto;
            dto.ClientId = 0;
            dto.ClientFirstName = "Nick";
            dto.ClientLastName = "Chan";
            dto.ClientEmail = "nc@emailcom";
            dto.ClientPhone = "+3437438973837";
            
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }
    }
}