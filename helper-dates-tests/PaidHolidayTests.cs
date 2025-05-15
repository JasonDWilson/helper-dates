using jwpro.DateHelper.Domain;
using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using Xunit;

namespace helper_dates_tests
{
	public class PaidHolidayTests
	{
		[Fact]
		public void GetDateCustomTests()
		{
			// arrange
			PaidHoliday holiday = new PaidHoliday(
				"Jason's Birthday",
				(string year) => SpecialDateHelper.GetChristmasDay(year).AddDays(-4));
			DateTime expected = DateTime.Parse("12/21/2020");
			// act
			DateTime? actual = holiday.GetDate("2020");
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("12/25/2020", "Christmas_Day", 0)]
		[InlineData("12/24/2020", "Christmas_Day", -1)]
		[InlineData("10/12/2020", "Columbus_Day", 0)]
		[InlineData("7/4/2020", "Independence_Day", 0)]
		[InlineData("9/7/2020", "Labor_Day", 0)]
		[InlineData("1/20/2020", "Martin_Luther_King_Jr_Day", 0)]
		[InlineData("5/25/2020", "Memorial_Day", 0)]
		[InlineData("1/1/2020", "New_Years_Day", 0)]
		[InlineData("12/31/2020", "New_Years_Day", 365)]
		[InlineData("2/17/2020", "Presidents_Day", 0)]
		[InlineData("11/26/2020", "Thanksgiving_Day", 0)]
		[InlineData("11/27/2020", "Thanksgiving_Day", 1)]
		[InlineData("11/11/2020", "Veterans_Day", 0)]
		public void GetDateStandardTests(string inputDate, string inputSpecialDate, int offSet)
		{
			// arrange
			DateTime expected = DateTime.Parse(inputDate);
			SpecialDate special = (SpecialDate)Enum.Parse(typeof(SpecialDate), inputSpecialDate);
			// act
			PaidHoliday holiday;
			if(offSet == 0)
			{
				holiday = new PaidHoliday(special);
			}
			else
			{
				holiday = new PaidHoliday($"{inputSpecialDate.Replace("_", " ")} Offset: {offSet}", special, offSet);
			}

			DateTime? actual = holiday.GetDate(expected.Year.ToString());
			//assert
			Assert.Equal(expected, actual);
		}
	}
}
