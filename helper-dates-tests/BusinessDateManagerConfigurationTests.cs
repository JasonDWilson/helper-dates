using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Managers;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace helper_dates_tests
{
    public class BusinessDateManagerConfigurationTests
    {
        private BusinessDateManagerConfiguration _businessConfig;
        private IConfiguration _config;

        public BusinessDateManagerConfigurationTests()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _businessConfig = new BusinessDateManagerConfiguration();
            _config.GetSection("BusinessDateManagerConfiguration").Bind(_businessConfig);
        }

        [Theory]
        [InlineData("Jasons Day", false)]
        [InlineData("Christmas Day", true)]
        [InlineData("Christmas Eve", true)]
        [InlineData("Independence Day", true)]
        [InlineData("Labor Day", true)]
        [InlineData("Memorial Day", true)]
        [InlineData("New Years Eve", true)]
        [InlineData("New Years Day", true)]
        [InlineData("Thanksgiving Day", true)]
        [InlineData("Day After Thanksgiving", true)]
        [InlineData("Jasons Birthday", true)]
        public void PaidHolidayContentTest(string name, bool expected)
        {
            // arrange
            // act
            var actual = _businessConfig.PaidHolidays.Any(x => x.Name == name);
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PaidHolidayCountTest()
        {
            // arrange
            // act
            var count = _businessConfig.PaidHolidays.Count;
            // assert
            Assert.Equal(10, count);
        }
    }
}
