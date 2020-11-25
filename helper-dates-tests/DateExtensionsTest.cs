using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace helper_dates_tests
{
    public class DateExtensionsTest
    {
        [Theory]
        [InlineData("11/25/2020", "Christmas_Eve", false)]
        [InlineData("12/24/2020", "Christmas_Eve", true)]
        [InlineData("11/25/2020", "Christmas_Day", false)]
        [InlineData("12/25/2020", "Christmas_Day", true)]
        [InlineData("11/25/2020", "Columbus_Day", false)]
        [InlineData("10/12/2020", "Columbus_Day", true)]
        [InlineData("11/25/2020", "Independence_Day", false)]
        [InlineData("7/4/2020", "Independence_Day", true)]
        [InlineData("11/25/2020", "Labor_Day", false)]
        [InlineData("9/7/2020", "Labor_Day", true)]
        [InlineData("11/25/2020", "Martin_Luther_King_Jr_Day", false)]
        [InlineData("1/20/2020", "Martin_Luther_King_Jr_Day", true)]
        [InlineData("11/25/2020", "Memorial_Day", false)]
        [InlineData("5/25/2020", "Memorial_Day", true)]
        [InlineData("11/25/2020", "New_Years_Day", false)]
        [InlineData("1/1/2020", "New_Years_Day", true)]
        [InlineData("11/25/2020", "New_Years_Eve", false)]
        [InlineData("12/31/2020", "New_Years_Eve", true)]
        [InlineData("11/25/2020", "Presidents_Day", false)]
        [InlineData("2/17/2020", "Presidents_Day", true)]
        [InlineData("11/25/2020", "Thanksgiving_Day", false)]
        [InlineData("11/26/2020", "Thanksgiving_Day", true)]
        [InlineData("11/25/2020", "Thanksgiving_Day_After", false)]
        [InlineData("11/27/2020", "Thanksgiving_Day_After", true)]
        [InlineData("11/25/2020", "Veterans_Day", false)]
        [InlineData("11/11/2020", "Veterans_Day", true)]
        public void SpecialDatesTest(string input, string special, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            var inputSpecial = (SpecialDates)Enum.Parse(typeof(SpecialDates), special);
            // act
            var specialDates = inputDate.SpecialDates();
            var isContained = specialDates.Contains(inputSpecial);
            //assert
            Assert.Equal(expected, isContained);
        }
    }
}
