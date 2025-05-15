using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Managers;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace helper_dates_tests
{
	public class BusinessDateManagerTests
	{
		private BusinesDateManager _manager;

		public BusinessDateManagerTests()
		{
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile(
				"appsettings.json",
				optional: false,
				reloadOnChange: true)
				.Build();
			BusinessDateManagerConfiguration businessConfig = new BusinessDateManagerConfiguration();
			config.GetSection("BusinessDateManagerConfiguration").Bind(businessConfig);
			_manager = new BusinesDateManager(businessConfig);
			//_manager.PaidHolidays
			//    .Add(new PaidHoliday("Jasons Birthday", (string year) => new DateTime(Int16.Parse(year), 12, 21)));
		}

		[Theory]
		[InlineData("11/2/2020 08:00", "11/2/2020 17:00", 9.0)] // normal difference
		[InlineData("11/2/2020 17:00", "11/2/2020 08:00", 0)] // negative difference
		[InlineData("11/2/2020 08:00", "11/2/2020 18:00", 9.0)] // ends after hours difference
		[InlineData("11/2/2020 08:00", "11/3/2020 09:00", 10.0)] // crosses a day
		[InlineData("11/2/2020 18:00", "11/3/2020 09:00", 1.0)] // crosses a day - begins after hours
		[InlineData("11/6/2020 08:00", "11/9/2020 09:00", 10.0)] // crosses a weekend - begins after hours
		public void GetBusinessHoursTest(string begin, string end, double expected)
		{
			// arrange
			DateTime beginDate = DateTime.Parse(begin);
			DateTime endDate = DateTime.Parse(end);
			// act
			double actual = _manager.GetBusinessHours(beginDate, endDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(null, "Christmas_Day", "12/25/2020")]
		[InlineData("Christmas Day", null, "12/25/2020")]
		[InlineData("Christmas Eve", null, "12/24/2020")]
		[InlineData(null, "Independence_Day", "7/4/2020")]
		[InlineData("Independence Day", null, "7/4/2020")]
		[InlineData(null, "Juneteenth_Day", "6/19/2020")]
		[InlineData("Juneteenth Day", null, "6/19/2020")]
		[InlineData(null, "Labor_Day", "9/7/2020")]
		[InlineData("Labor Day", null, "9/7/2020")]
		[InlineData(null, "Memorial_Day", "5/25/2020")]
		[InlineData("Memorial Day", null, "5/25/2020")]
		[InlineData(null, "New_Years_Day", "1/1/2020")]
		[InlineData("New Years Day", null, "1/1/2020")]
		[InlineData("New Years Eve", null, "12/31/2020")]
		[InlineData(null, "Thanksgiving_Day", "11/26/2020")]
		[InlineData("Thanksgiving Day", null, "11/26/2020")]
		[InlineData("Day After Thanksgiving", null, "11/27/2020")]
		[InlineData("Jasons Birthday", null, "12/21/2020")]
		public void GetPaidHolidayDateTest(string name, string specialName, DateTime expected)
		{
			// arrange
			DateTime? actual = DateTime.Now;
			SpecialDate special = 0;
			if(!string.IsNullOrWhiteSpace(specialName))
			{
				special = (SpecialDate)Enum.Parse(typeof(SpecialDate), specialName);
			}
			// act
			if(!string.IsNullOrWhiteSpace(specialName))
			{
				actual = _manager.GetPaidHolidayDate(special, "2020");
			}
			else
			{
				actual = _manager.GetPaidHolidayDate(name, "2020");
			}
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("5/15/2025 16:00", false)]
		[InlineData("5/15/2025 17:00", true)]
		[InlineData("5/15/2025 18:00", true)]
		public void IsAfterHoursTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = _manager.IsAfterHours(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("12/22/2020", false)]
		[InlineData("12/25/2020", true)]
		[InlineData("7/4/2020", true)]
		[InlineData("9/7/2020", true)]
		[InlineData("6/19/2020", true)]
		[InlineData("5/25/2020", true)]
		[InlineData("1/1/2020", true)]
		[InlineData("12/31/2020", true)]
		[InlineData("11/26/2020", true)]
		[InlineData("11/27/2020", true)]
		[InlineData("12/21/2020", true)]
		public void IsPaidHolidayTest(string input, bool expected)
		{
			// arrange
			DateTime inputDate = DateTime.Parse(input);
			// act
			bool actual = _manager.IsPaidHoliday(inputDate);
			// assert
			Assert.Equal(expected, actual);
		}
	}
}
