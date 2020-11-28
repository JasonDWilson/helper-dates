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
        [InlineData("New Years Eve", true)]
        [InlineData("New Years Day", true)]
        [InlineData("Thanksgiving Day", true)]
        [InlineData("Day After Thanksgiving", true)]
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
            Assert.Equal(4, count);
        }
    }
}
