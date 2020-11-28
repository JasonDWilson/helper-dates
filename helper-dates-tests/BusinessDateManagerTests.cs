using jwpro.DateHelper.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // act
            var ph = _businessConfig.PaidHolidays.FirstOrDefault(x => x.Name == name);
            var actual = ph.GetDate("2020");
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
