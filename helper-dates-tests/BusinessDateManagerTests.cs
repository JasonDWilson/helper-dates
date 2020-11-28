using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Managers;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace helper_dates_tests
{
    public class BusinessDateManagerTests
    {
        private BusinessDateManagerConfiguration _businessConfig;
        private IConfiguration _config;

        public BusinessDateManagerTests()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _businessConfig = new BusinessDateManagerConfiguration();
            _config.GetSection("BusinessDateManagerConfiguration").Bind(_businessConfig);
        }

        [Theory]
        [InlineData("New Years Eve", "12/31/2020")]
        [InlineData("New Years Day", "1/1/2020")]
        [InlineData("Thanksgiving Day", "11/26/2020")]
        [InlineData("Day After Thanksgiving", "11/27/2020")]
        public void PaidHolidayContentTest(string name, string inputDate)
        {
            // arrange
            var expected = DateTime.Parse(inputDate);
            var manager = new BusinesDateManager(_businessConfig);
            // act
            var ph = manager.PaidHolidays.FirstOrDefault(x => x.Name == name);
            var actual = ph.GetDate("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PaidHolidayCountTest()
        {
            // arrange
            var manager = new BusinesDateManager(_businessConfig);
            // act
            var count = manager.PaidHolidays.Count;
            // assert
            Assert.Equal(4, count);
        }
    }
}
