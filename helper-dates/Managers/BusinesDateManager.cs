using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Domain;
using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace jwpro.DateHelper.Managers
{
	public class BusinesDateManager : IBusinesDateManager
	{
		private BusinessDateManagerConfiguration _config;

		public BusinesDateManager(BusinessDateManagerConfiguration config)
		{ _config = config ?? throw new ArgumentNullException(nameof(config)); }

		public double GetBusinessHours(DateTime from, DateTime to)
		{
			// Check for Start After End
			if(to <= from)
			{
				return 0;
			}

			// Test if Start is on a Weekend
			if(from.DayOfWeek == DayOfWeek.Saturday)
			{
				from = DateTime.Parse($"{from.AddDays(2).ToShortDateString()} {_config.BusinessDayBegin}");
			}
			else if(from.DayOfWeek == DayOfWeek.Sunday)
			{
				from = DateTime.Parse($"{from.AddDays(1).ToShortDateString()} {_config.BusinessDayBegin}");
			}

			// Test if End is on a Weekend
			if(to.DayOfWeek == DayOfWeek.Saturday)
			{
				to = DateTime.Parse($"{to.AddDays(2).ToShortDateString()} {_config.BusinessDayBegin}");
			}
			else if(to.DayOfWeek == DayOfWeek.Sunday)
			{
				to = DateTime.Parse($"{to.AddDays(1).ToShortDateString()} {_config.BusinessDayBegin}");
			}

			// *** If Start Before Busineess Hours Adjust Start Time to Beginning of Business Hours ***
			DateTime businessDayBegin = DateTime.Parse($"{from.ToShortDateString()} {_config.BusinessDayBegin}");
			if(from < businessDayBegin)
			{
				from = businessDayBegin;
			}

			// *** If End Before Busineess Hours Adjust End Time to Beginning of Business Hours ***
			if(businessDayBegin > to)
			{
				to = businessDayBegin;
			}

			// *** If Start After Business Hours Adjust Start to Beginning of Business Hours on Next Day ***
			DateTime businessDayEnd = DateTime.Parse($"{from.ToShortDateString()} {_config.BusinessDayEnd}");
			if(businessDayEnd < from)
			{
				if(from.DayOfWeek != DayOfWeek.Friday)
				{
					from = DateTime.Parse($"{from.AddDays(1).ToShortDateString()} {_config.BusinessDayBegin}");
				}
				else
				{
					from = DateTime.Parse($"{from.AddDays(3).ToShortDateString()} {_config.BusinessDayBegin}");
				}
			}

			// *** If End After Business Hours Adjust Start to Beginning of Business Hours on Next Day ***
			businessDayEnd = DateTime.Parse($"{to.ToShortDateString()} {_config.BusinessDayEnd}");
			if(businessDayEnd < to)
			{
				if(to.DayOfWeek != DayOfWeek.Friday)
				{
					to = DateTime.Parse($"{to.AddDays(1).ToShortDateString()} {_config.BusinessDayBegin}");
				}
				else
				{
					to = DateTime.Parse($"{to.AddDays(3).ToShortDateString()} {_config.BusinessDayBegin}");
				}
			}

			// *** Calculate Hours Difference***
			double hours = to.Subtract(from).TotalHours;

			// Calculate Day Modifier
			// as the difference in hours between the end of one business day and the beginning of another
			// This is without a weekend between
			TimeSpan overnight = DateTime.Parse($"11/3/2020 {_config.BusinessDayBegin}")
				.Subtract(DateTime.Parse($"11/2/2020 {_config.BusinessDayEnd}"));
			int overnightHours = overnight.Hours;

			// *** Adjust Business Hours For Start and End on Different Days (remove non business hours) ***
			int days = to.Subtract(from).Days;
			int modifiedHours;
			if(days > 0)
			{
				modifiedHours = days * overnightHours;
			}
			else
			{
				modifiedHours = 0;
			}

			// Calculate Week Modifier
			// as the number of non business hours
			// to be discounted because of a start and end in different
			// work weeks -- keep in mind that there is already
			// a modifier for each day so that the total modifier is:
			// total modifier = day modifier + week modifier
			int overWeekHours = 2 * (24 - overnightHours);
			CultureInfo ci = new CultureInfo("en-US");
			Calendar calendar = ci.Calendar;
			int weeks = calendar.GetWeekOfYear(to, CalendarWeekRule.FirstDay, DayOfWeek.Sunday) -
				calendar.GetWeekOfYear(from, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
			if(weeks < 0)
			{
				weeks = (calendar.GetWeekOfYear(
							DateTime.Parse($"12/31/{from.Year} {_config.BusinessDayEnd}"),
							CalendarWeekRule.FirstDay,
							DayOfWeek.Sunday) -
						calendar.GetWeekOfYear(from, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)) +
					(calendar.GetWeekOfYear(to, CalendarWeekRule.FirstDay, DayOfWeek.Sunday) -
						calendar.GetWeekOfYear(
							DateTime.Parse($"1/1/{to.Year} {_config.BusinessDayBegin}"),
							CalendarWeekRule.FirstDay,
							DayOfWeek.Sunday));
			}

			if(weeks > 0)
			{
				modifiedHours += weeks * overWeekHours;
			}

			return Math.Round(hours - modifiedHours, 2);
		}

		public DateTime? GetPaidHolidayDate(string name, string year)
		{
			PaidHoliday holiday = PaidHolidays.FirstOrDefault(x => x.Name == name);
			if(holiday != null)
			{
				return holiday.GetDate(year);
			}

			return null;
		}

		public DateTime? GetPaidHolidayDate(SpecialDate special, string year)
		{
			PaidHoliday holiday = PaidHolidays.FirstOrDefault(x => x.AssociatedSpecialDate == special);
			if(holiday != null)
			{
				return holiday.GetDate(year);
			}

			return null;
		}

		public bool IsAfterHours(DateTime input)
		{
			DateTime testDate = DateTime.Parse($"{input:yyyy-MM-dd} {_config.BusinessDayEnd}");
			return input >= testDate;
		}

		public bool IsBusinessDay(DateTime input)
		{
			// Check if the date is a weekend
			if(input.IsWeekEnd())
			{
				return false;
			}
			// Check if the date is a paid holiday
			if(IsPaidHoliday(input))
			{
				return false;
			}
			// If it's not a weekend or a paid holiday, it's a business day
			return true;
		}

		public bool IsPaidHoliday(DateTime input)
		{
			foreach(PaidHoliday holiday in _config.PaidHolidays)
			{
				if(holiday.GetDate(input.Year.ToString()) == input.Date)
				{
					return true;
				}
			}

			return false;
		}

		public List<PaidHoliday> PaidHolidays => _config.PaidHolidays;
	}
}
