using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Managers;
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
        private BusinesDateManager _manager;

        public BusinessDateManagerTests()
        {
            var config = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json",
                optional: false,
                reloadOnChange: true)
                .Build();
            var businessConfig = new BusinessDateManagerConfiguration();
            config.GetSection("BusinessDateManagerConfiguration").Bind(businessConfig);
            _manager = new BusinesDateManager(businessConfig);
        }

        [Theory]
        [InlineData("12/21/2020", false)]
        [InlineData("12/25/2020", true)]
        [InlineData("7/4/2020", true)]
        [InlineData("9/7/2020", true)]
        [InlineData("5/25/2020", true)]
        [InlineData("1/1/2020", true)]
        [InlineData("12/31/2020", true)]
        [InlineData("11/26/2020", true)]
        [InlineData("11/27/2020", true)]
        public void IsPaidHolidayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = _manager.IsPaidHoliday(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
