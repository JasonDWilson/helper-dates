using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using Xunit;

namespace helper_dates_tests
{
	public class SpecialDateHelperTests
	{
		[Fact]
		public void GetChristmasDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("12/25/2020");
			// act
			DateTime actual = SpecialDateHelper.GetChristmasDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetChristmasEveTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("12/24/2020");
			// act
			DateTime actual = SpecialDateHelper.GetChristmasEve("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetColumbusDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("10/12/2020");
			// act
			DateTime actual = SpecialDateHelper.GetColumbusDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetIndependenceDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("7/4/2020");
			// act
			DateTime actual = SpecialDateHelper.GetIndependenceDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetLaborDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("9/7/2020");
			// act
			DateTime actual = SpecialDateHelper.GetLaborDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetMartinLutherKingJrDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("1/20/2020");
			// act
			DateTime actual = SpecialDateHelper.GetMartinLutherKingJrDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetMemorialDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("5/25/2020");
			// act
			DateTime actual = SpecialDateHelper.GetMemorialDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetNewYearsDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("1/1/2020");
			// act
			DateTime actual = SpecialDateHelper.GetNewYearsDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetNewYearsEveTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("12/31/2020");
			// act
			DateTime actual = SpecialDateHelper.GetNewYearsEve("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetPresidentsDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("2/17/2020");
			// act
			DateTime actual = SpecialDateHelper.GetPresidentsDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}


		[Theory]
		[InlineData("12/25/2020", "2020", SpecialDate.Christmas_Day)]
		[InlineData("10/12/2020", "2020", SpecialDate.Columbus_Day)]
		[InlineData("7/4/2020", "2020", SpecialDate.Independence_Day)]
		[InlineData("9/7/2020", "2020", SpecialDate.Labor_Day)]
		[InlineData("1/20/2020", "2020", SpecialDate.Martin_Luther_King_Jr_Day)]
		[InlineData("5/25/2020", "2020", SpecialDate.Memorial_Day)]
		[InlineData("1/1/2020", "2020", SpecialDate.New_Years_Day)]
		[InlineData("12/31/2020", "2020", SpecialDate.New_Years_Eve)]
		[InlineData("2/17/2020", "2020", SpecialDate.Presidents_Day)]
		[InlineData("11/26/2020", "2020", SpecialDate.Thanksgiving_Day)]
		[InlineData("11/11/2020", "2020", SpecialDate.Veterans_Day)]
		public void GetSpecialDateTest(string inputExpected, string inputYear, SpecialDate special)
		{
			// arrange
			DateTime expected = DateTime.Parse(inputExpected);

			// act
			DateTime actual = SpecialDateHelper.GetSpecialDate(special, inputYear);

			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetThanksgivingDayAfterTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("11/27/2020");
			// act
			DateTime actual = SpecialDateHelper.GetThanksgivingDayAfter("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetThanksgivingDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("11/26/2020");
			// act
			DateTime actual = SpecialDateHelper.GetThanksgivingDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetVeteransDayTest()
		{
			// arrange
			DateTime expected = DateTime.Parse("11/11/2020");
			// act
			DateTime actual = SpecialDateHelper.GetVeteransDay("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("12/25/2020", true)]
		public void IsChristmasDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = SpecialDateHelper.IsChristmasDay(inputDate);

			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("12/24/2020", true)]
		public void IsChristmasEveTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = SpecialDateHelper.IsChristmasEve(inputDate);

			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("10/12/2020", true)]
		public void IsColumbusDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = SpecialDateHelper.IsColumbusDay(inputDate);

			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("7/4/2020", true)]
		public void IsIndependenceTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = SpecialDateHelper.IsIndependenceDay(inputDate);

			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("9/7/2020", true)]
		public void IsLaborDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsLaborDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("1/20/2020", true)]
		public void IsMartinLutherKingJrDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsMartinLutherKingJrDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("5/25/2020", true)]
		public void IsMemorialDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsMemorialDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("1/1/2020", true)]
		public void IsNewYearsDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsNewYearsDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("12/31/2020", true)]
		public void IsNewYearsEveTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsNewYearsEve(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("2/17/2020", true)]
		public void IsPresidentsDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsPresidentsDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("1/25/2020", false)]
		[InlineData("1/1/2020", true)]
		[InlineData("1/20/2020", true)]
		[InlineData("2/17/2020", true)]
		[InlineData("5/25/2020", true)]
		[InlineData("7/4/2020", true)]
		[InlineData("9/7/2020", true)]
		[InlineData("10/12/2020", true)]
		[InlineData("11/11/2020", true)]
		[InlineData("11/26/2020", true)]
		[InlineData("11/27/2020", true)]
		[InlineData("12/24/2020", true)]
		[InlineData("12/25/2020", true)]
		[InlineData("12/31/2020", true)]
		public void IsSpecialDateTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsSpecialDate(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("11/27/2020", true)]
		public void IsThanksgivingDayAfterTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsThanksgivingDayAfter(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("11/26/2020", true)]
		public void IsThanksgivingDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsThanksgivingDay(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("11/11/2020", true)]
		public void IsVeteransDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsVeteransDay(inputDate);
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
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsWeekDay(inputDate);
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
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = SpecialDateHelper.IsWeekEnd(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}
	}
}

