using System;
using System.Linq;

namespace OnlineBookingAggregatorApp.Infrastructure.Utils
{
    public class RandomStringGenerator
    {
        private static readonly Random Random = new Random();
        private const string AllowedChars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";

        public static string GenerateRandomString(int length)
        {
            var str = Enumerable.Repeat(AllowedChars, length)
                .Select(x => x[Random.Next(x.Length)]).ToArray();

            return new string(str);
        }

        public static string GenerateRandomCode(int length)
        {
            var str = Enumerable.Repeat(Digits, length)
                .Select(x => x[Random.Next(x.Length)]).ToArray();

            return new string(str);
        }
    }
}