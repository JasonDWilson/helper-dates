﻿using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Exceptions;
using jwpro.DateHelper.Extensions;
using System;

namespace jwpro.DateHelper.Helpers
{
	public static class SpecialDateHelper
	{
		public static DateTime GetChristmasDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"12/25/{year}");
		}

		public static DateTime GetChristmasEve(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"12/24/{year}");
		}

		public static DateTime GetColumbusDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"10/12/{year}");
		}

		public static DateTime GetIndependenceDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"7/4/{year}");
		}

		public static DateTime GetJuneteenth(string  year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"6/19/{year}");
		}

		public static DateTime GetLaborDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			for(short x = 1; x <= 30; x++)
			{
				DateTime test = DateTime.Parse($"9/{x}/{year}");
				if(test.DayOfWeek == DayOfWeek.Monday)
				{
					return test;
				}
			}
			return DateTime.Now; // it will never get here
		}

		public static DateTime GetMartinLutherKingJrDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"1/20/{year}");
		}

		public static DateTime GetMemorialDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			for(short x = 31; x >= 1; x += -1)
			{
				DateTime test = DateTime.Parse($"5/{x}/{year}");
				if(test.DayOfWeek == DayOfWeek.Monday)
				{
					return test;
				}
			}
			return DateTime.Now; // it will never get here
		}

		public static DateTime GetNewYearsDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"1/1/{year}");
		}

		public static DateTime GetNewYearsEve(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"12/31/{year}");
		}

		public static DateTime GetPresidentsDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"2/17/{year}");
		}

		public static DateTime GetSpecialDate(SpecialDate special, string year)
		{
			switch(special)
			{
				case SpecialDate.Christmas_Day:
					return SpecialDateHelper.GetChristmasDay(year);
				case SpecialDate.Columbus_Day:
					return SpecialDateHelper.GetColumbusDay(year);
				case SpecialDate.Independence_Day:
					return SpecialDateHelper.GetIndependenceDay(year);
				case SpecialDate.Juneteenth_Day:
					return SpecialDateHelper.GetJuneteenth(year);
				case SpecialDate.Labor_Day:
					return SpecialDateHelper.GetLaborDay(year);
				case SpecialDate.Martin_Luther_King_Jr_Day:
					return SpecialDateHelper.GetMartinLutherKingJrDay(year);
				case SpecialDate.Memorial_Day:
					return SpecialDateHelper.GetMemorialDay(year);
				case SpecialDate.New_Years_Day:
					return SpecialDateHelper.GetNewYearsDay(year);
				case SpecialDate.New_Years_Eve:
					return SpecialDateHelper.GetNewYearsEve(year);
				case SpecialDate.Presidents_Day:
					return SpecialDateHelper.GetPresidentsDay(year);
				case SpecialDate.Thanksgiving_Day:
					return SpecialDateHelper.GetThanksgivingDay(year);
				case SpecialDate.Veterans_Day:
					return SpecialDateHelper.GetVeteransDay(year);
				default:
					throw new NotSupportedSpecialDateException($"{special} is not a currently supported special date");
			}
		}

		public static DateTime GetThanksgivingDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			int thursdayCount = 0;
			for(short x = 1; x <= 30; x++)
			{
				DateTime test = DateTime.Parse($"11/{x}/{year}");
				if(test.DayOfWeek == DayOfWeek.Thursday)
				{
					thursdayCount++;
					if(thursdayCount == 4)
					{
						return test;
					}
				}
			}
			return DateTime.Now;
		}

		public static DateTime GetThanksgivingDayAfter(string year) { return GetThanksgivingDay(year).AddDays(1); }

		public static DateTime GetVeteransDay(string year)
		{
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			return DateTime.Parse($"11/11/{year}");
		}

		public static bool IsChristmasDay(DateTime input)
		{ return input.Date == GetChristmasDay(input.Year.ToString()); }

		public static bool IsChristmasEve(DateTime input)
		{ return input.Date == GetChristmasEve(input.Year.ToString()); }

		public static bool IsColumbusDay(DateTime input) { return input.Date == GetColumbusDay(input.Year.ToString()); }

		public static bool IsIndependenceDay(DateTime input)
		{ return input.Date == GetIndependenceDay(input.Year.ToString()); }

		public static bool IsJuneteenth(DateTime input) { return input.Date == GetJuneteenth(input.Year.ToString()); }

		public static bool IsLaborDay(DateTime input) { return input.Date == GetLaborDay(input.Year.ToString()); }

		public static bool IsMartinLutherKingJrDay(DateTime input)
		{ return input.Date == GetMartinLutherKingJrDay(input.Year.ToString()); }

		public static bool IsMemorialDay(DateTime input) { return input.Date == GetMemorialDay(input.Year.ToString()); }

		public static bool IsNewYearsDay(DateTime input) { return input.Date == GetNewYearsDay(input.Year.ToString()); }

		public static bool IsNewYearsEve(DateTime input) { return input.Date == GetNewYearsEve(input.Year.ToString()); }

		public static bool IsPresidentsDay(DateTime input)
		{ return input.Date == GetPresidentsDay(input.Year.ToString()); }

		public static bool IsSpecialDate(DateTime input)
		{
			return input.IsChristmasDay() ||
				input.IsChristmasEve() ||
				input.IsColumbusDay() ||
				input.IsIndependenceDay() ||
				input.IsLaborDay() ||
				input.IsMartinLutherKingJrDay() ||
				input.IsMemorialDay() ||
				input.IsNewYearsDay() ||
				input.IsNewYearsEve() ||
				input.IsPresidentsDay() ||
				input.IsThanksgivingDay() ||
				input.IsThanksgivingDayAfter() ||
				input.IsVeteransDay();
		}


		public static bool IsThanksgivingDay(DateTime input)
		{ return input.Date == GetThanksgivingDay(input.Year.ToString()); }

		public static bool IsThanksgivingDayAfter(DateTime input)
		{ return input.Date == GetThanksgivingDayAfter(input.Year.ToString()); }

		public static bool IsVeteransDay(DateTime input) { return input.Date == GetVeteransDay(input.Year.ToString()); }

		public static bool IsWeekDay(DateTime input) { return !IsWeekEnd(input); }

		public static bool IsWeekEnd(DateTime input)
		{ return (input.DayOfWeek == DayOfWeek.Saturday) || (input.DayOfWeek == DayOfWeek.Sunday); }
	}
}
