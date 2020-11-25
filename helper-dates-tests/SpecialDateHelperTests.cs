using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using System.Linq;
using Xunit;

namespace helper_dates_tests
{
    public class SpecialDateHelperTests
    {
        [Fact]
        public void GetChristmasDayTest()
        {
            // arrange
            var expected = DateTime.Parse("12/25/2020");
            // act
            var actual = SpecialDateHelper.GetChristmasDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetChristmasEveTest()
        {
            // arrange
            var expected = DateTime.Parse("12/24/2020");
            // act
            var actual = SpecialDateHelper.GetChristmasEve("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetColumbusDayTest()
        {
            // arrange
            var expected = DateTime.Parse("10/12/2020");
            // act
            var actual = SpecialDateHelper.GetColumbusDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetIndependenceDayTest()
        {
            // arrange
            var expected = DateTime.Parse("7/4/2020");
            // act
            var actual = SpecialDateHelper.GetIndependenceDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLaborDayTest()
        {
            // arrange
            var expected = DateTime.Parse("9/7/2020");
            // act
            var actual = SpecialDateHelper.GetLaborDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMartinLutherKingJrDayTest()
        {
            // arrange
            var expected = DateTime.Parse("1/20/2020");
            // act
            var actual = SpecialDateHelper.GetMartinLutherKingJrDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMemorialDayTest()
        {
            // arrange
            var expected = DateTime.Parse("5/25/2020");
            // act
            var actual = SpecialDateHelper.GetMemorialDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNewYearsDayTest()
        {
            // arrange
            var expected = DateTime.Parse("1/1/2020");
            // act
            var actual = SpecialDateHelper.GetNewYearsDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNewYearsEveTest()
        {
            // arrange
            var expected = DateTime.Parse("12/31/2020");
            // act
            var actual = SpecialDateHelper.GetNewYearsEve("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPresidentsDayTest()
        {
            // arrange
            var expected = DateTime.Parse("2/17/2020");
            // act
            var actual = SpecialDateHelper.GetPresidentsDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("12/25/2020", "2020", SpecialDates.Christmas_Day)]
        [InlineData("12/24/2020", "2020", SpecialDates.Christmas_Eve)]
        [InlineData("10/12/2020", "2020", SpecialDates.Columbus_Day)]
        [InlineData("7/4/2020", "2020", SpecialDates.Independence_Day)]
        [InlineData("9/7/2020", "2020", SpecialDates.Labor_Day)]
        [InlineData("1/20/2020", "2020", SpecialDates.Martin_Luther_King_Jr_Day)]
        [InlineData("5/25/2020", "2020", SpecialDates.Memorial_Day)]
        [InlineData("1/1/2020", "2020", SpecialDates.New_Years_Day)]
        [InlineData("12/31/2020", "2020", SpecialDates.New_Years_Eve)]
        [InlineData("2/17/2020", "2020", SpecialDates.Presidents_Day)]
        [InlineData("11/26/2020", "2020", SpecialDates.Thanksgiving_Day)]
        [InlineData("11/27/2020", "2020", SpecialDates.Thanksgiving_Day_After)]
        [InlineData("11/11/2020", "2020", SpecialDates.Veterans_Day)]
        public void GetSpecialDateTest(string inputExpected, string inputYear, SpecialDates special)
        {
            // arrange
            var expected = DateTime.Parse(inputExpected);

            // act
            var actual = SpecialDateHelper.GetSpecialDate(special, inputYear);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetThanksgivingDayAfterTest()
        {
            // arrange
            var expected = DateTime.Parse("11/27/2020");
            // act
            var actual = SpecialDateHelper.GetThanksgivingDayAfter("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetThanksgivingDayTest()
        {
            // arrange
            var expected = DateTime.Parse("11/26/2020");
            // act
            var actual = SpecialDateHelper.GetThanksgivingDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetVeteransDayTest()
        {
            // arrange
            var expected = DateTime.Parse("11/11/2020");
            // act
            var actual = SpecialDateHelper.GetVeteransDay("2020");
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("12/25/2020", true)]
        public void IsChristmasDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);

            // act
            var actual = SpecialDateHelper.IsChristmasDay(inputDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("12/24/2020", true)]
        public void IsChristmasEveTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);

            // act
            var actual = SpecialDateHelper.IsChristmasEve(inputDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("10/12/2020", true)]
        public void IsColumbusDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);

            // act
            var actual = SpecialDateHelper.IsColumbusDay(inputDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("7/4/2020", true)]
        public void IsIndependenceTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);

            // act
            var actual = SpecialDateHelper.IsIndependenceDay(inputDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("9/7/2020", true)]
        public void IsLaborDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsLaborDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("1/20/2020", true)]
        public void IsMartinLutherKingJrDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsMartinLutherKingJrDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("5/25/2020", true)]
        public void IsMemorialDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsMemorialDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("1/1/2020", true)]
        public void IsNewYearsDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsNewYearsDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("12/31/2020", true)]
        public void IsNewYearsEveTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsNewYearsEve(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("2/17/2020", true)]
        public void IsPresidentsDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsPresidentsDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("11/27/2020", true)]
        public void IsThanksgivingDayAfterTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsThanksgivingDayAfter(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("11/26/2020", true)]
        public void IsThanksgivingDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsThanksgivingDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/25/2020", false)]
        [InlineData("11/11/2020", true)]
        public void IsVeteransDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsVeteransDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/1/2020", false)]
        [InlineData("11/2/2020", true)]
        [InlineData("11/3/2020", true)]
        [InlineData("11/4/2020", true)]
        [InlineData("11/5/2020", true)]
        [InlineData("11/6/2020", true)]
        [InlineData("11/7/2020", false)]
        public void IsWeekDayTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsWeekDay(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11/1/2020", true)]
        [InlineData("11/2/2020", false)]
        [InlineData("11/3/2020", false)]
        [InlineData("11/4/2020", false)]
        [InlineData("11/5/2020", false)]
        [InlineData("11/6/2020", false)]
        [InlineData("11/7/2020", true)]
        public void IsWeekEndTest(string input, bool expected)
        {
            // arrange
            var inputDate = DateTime.Parse(input);
            // act
            var actual = SpecialDateHelper.IsWeekEnd(inputDate);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}

