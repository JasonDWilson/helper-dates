﻿using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace helper_dates_tests
{
	public class DateExtensionsTest
	{
		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("12/25/2020", true)]
		public void IsChristmasDayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = inputDate.IsChristmasDay();

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
			bool actual = inputDate.IsChristmasEve();

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
			bool actual = inputDate.IsColumbusDay();

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
			bool actual = inputDate.IsIndependenceDay();

			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("11/25/2020", false)]
		[InlineData("11/25/2020 23:00", false)]
		[InlineData("6/19/2020", true)]
		[InlineData("6/19/2020 23:00", true)]
		public void IsJuneteenthTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);

			// act
			bool actual = inputDate.IsJuneteenthDay();

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
			bool actual = inputDate.IsLaborDay();

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
			bool actual = inputDate.IsMartinLutherKingJrDay();

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
			bool actual = inputDate.IsMemorialDay();

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
			bool actual = inputDate.IsNewYearsDay();

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
			bool actual = inputDate.IsNewYearsEve();

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
			bool actual = inputDate.IsPresidentsDay();

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
			bool actual = inputDate.IsSpecialDate();
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
			bool actual = inputDate.IsThanksgivingDayAfter();

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
			bool actual = inputDate.IsThanksgivingDay();

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
			bool actual = inputDate.IsVeteransDay();

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
			bool actual = inputDate.IsWeekDay();
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
			bool actual = inputDate.IsWeekEnd();
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
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
		[InlineData("11/25/2020", "Veterans_Day", false)]
		[InlineData("11/11/2020", "Veterans_Day", true)]
		public void SpecialDatesTest(string input, string special, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			SpecialDate inputSpecial = (SpecialDate)Enum.Parse(typeof(SpecialDate), special);
			// act
			IEnumerable<SpecialDate> specialDates = inputDate.SpecialDates();
			bool isContained = specialDates.Contains(inputSpecial);
			//assert
			Assert.Equal(expected, isContained);
		}
	}
}
