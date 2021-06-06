using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using Xunit;

namespace OnlineBookingAggregatorApp.UnitTests.Infrastructure.Validators
{
    public class ClientCreateUpdateDtoValidatorTests
    {
        private readonly ClientCreateUpdateDtoValidator _sut = new();

        private readonly ClientCreateUpdateDto _validDto = new()
        {
            FirstName = "Dylan",
            LastName = "Wang",
            PhoneNumber = "123456789",
            AdditionalPhoneNumber = null,
            Email = "jperm@email.ca",
            ClientCategory = ClientCategory.VIP,
            Gender = Gender.Male,
            Comments = "Comments"
        };

        [Fact]
        public void WithAValidDto()
        {
            var dto = _validDto;
            var result = _sut.Validate(dto);
            Assert.Equal(0, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithEmptyFirstAndLastName()
        {
            var dto = _validDto;
            dto.FirstName = string.Empty;
            dto.LastName = string.Empty;
            var result = _sut.Validate(dto);
            Assert.Equal(2, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithFirstAndLastNameExceedFortyCharacters()
        {
            var dto = _validDto;
            dto.FirstName = "qwelgerhgworuhrbpogurbgpogburpguobrpiorbgpribgurpi";
            dto.LastName = "firngrpionriopntoitntointrogitngotintoigntogitngoi";
            var result = _sut.Validate(dto);
            Assert.Equal(2, result.Errors.Count);
        }

        [Fact]
        public void WithAValidDtoWithInvalidEmail()
        {
            var dto = _validDto;
            dto.Email = "jperm@email.ca";
            var result = _sut.Validate(dto);
            Assert.Equal(1, result.Errors.Count);
        }
    }
}