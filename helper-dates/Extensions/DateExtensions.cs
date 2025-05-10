using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using System.Collections.Generic;

namespace jwpro.DateHelper.Extensions
{
	public static class DateExtensions
	{
		public static bool IsChristmasDay(this DateTime input) { return SpecialDateHelper.IsChristmasDay(input); }

		public static bool IsChristmasEve(this DateTime input) { return SpecialDateHelper.IsChristmasEve(input); }

		public static bool IsColumbusDay(this DateTime input) { return SpecialDateHelper.IsColumbusDay(input); }

		public static bool IsIndependenceDay(this DateTime input) { return SpecialDateHelper.IsIndependenceDay(input); }

		public static bool IsLaborDay(this DateTime input) { return SpecialDateHelper.IsLaborDay(input); }

		public static bool IsMartinLutherKingJrDay(this DateTime input)
		{ return SpecialDateHelper.IsMartinLutherKingJrDay(input); }

		public static bool IsMemorialDay(this DateTime input) { return SpecialDateHelper.IsMemorialDay(input); }

		public static bool IsNewYearsDay(this DateTime input) { return SpecialDateHelper.IsNewYearsDay(input); }

		public static bool IsNewYearsEve(this DateTime input) { return SpecialDateHelper.IsNewYearsEve(input); }

		public static bool IsPresidentsDay(this DateTime input) { return SpecialDateHelper.IsPresidentsDay(input); }

		public static bool IsSpecialDate(this DateTime input) { return SpecialDateHelper.IsSpecialDate(input); }

		public static bool IsThanksgivingDay(this DateTime input) { return SpecialDateHelper.IsThanksgivingDay(input); }

		public static bool IsThanksgivingDayAfter(this DateTime input)
		{ return SpecialDateHelper.IsThanksgivingDayAfter(input); }

		public static bool IsVeteransDay(this DateTime input) { return SpecialDateHelper.IsVeteransDay(input); }

		public static bool IsWeekDay(this DateTime input) { return SpecialDateHelper.IsWeekDay(input); }

		public static bool IsWeekEnd(this DateTime input) { return SpecialDateHelper.IsWeekEnd(input); }

		public static IEnumerable<SpecialDate> SpecialDates(this DateTime input)
		{
			List<SpecialDate> result = new List<SpecialDate>();
			foreach(SpecialDate special in Enum.GetValues(typeof(SpecialDate)))
			{
				if((special != SpecialDate.Custom) &&
					(SpecialDateHelper.GetSpecialDate(special, input.Year.ToString()) == input))
				{
					result.Add(special);
				}
			}

			return result;
		}
	}
}
