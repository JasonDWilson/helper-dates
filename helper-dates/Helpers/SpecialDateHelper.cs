using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Exceptions;
using jwpro.DateHelper.Extensions;
using System;
using System.Linq;

namespace jwpro.DateHelper.Helpers
{
    public static class SpecialDateHelper
    {
        public static DateTime GetChristmasDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"12/25/{year}");
        }

        public static DateTime GetChristmasEve(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"12/24/{year}");
        }

        public static DateTime GetColumbusDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"10/12/{year}");
        }

        public static DateTime GetIndependenceDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"7/4/{year}");
        }

        public static DateTime GetLaborDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            for(Int16 x = 1; x <= 30; x++)
            {
                var test = DateTime.Parse($"9/{x}/{year}");
                if(test.DayOfWeek == DayOfWeek.Monday)
                    return test;
            }
            return DateTime.Now; // it will never get here
        }

        public static DateTime GetMartinLutherKingJrDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"1/20/{year}");
        }

        public static DateTime GetMemorialDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            for(Int16 x = 31; x >= 1; x += -1)
            {
                var test = DateTime.Parse($"5/{x}/{year}");
                if(test.DayOfWeek == DayOfWeek.Monday)
                    return test;
            }
            return DateTime.Now; // it will never get here
        }

        public static DateTime GetNewYearsDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"1/1/{year}");
        }

        public static DateTime GetNewYearsEve(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"12/31/{year}");
        }

        public static DateTime GetPresidentsDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

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
                year = DateTime.Now.Year.ToString();

            int thursdayCount = 0;
            for(Int16 x = 1; x <= 30; x++)
            {
                var test = DateTime.Parse($"11/{x}/{year}");
                if(test.DayOfWeek == DayOfWeek.Thursday)
                {
                    thursdayCount++;
                    if(thursdayCount == 4)
                        return test;
                }
            }
            return DateTime.Now;
        }

        public static DateTime GetThanksgivingDayAfter(string year) => GetThanksgivingDay(year).AddDays(1);

        public static DateTime GetVeteransDay(string year)
        {
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.Year.ToString();

            return DateTime.Parse($"11/11/{year}");
        }

        public static bool IsChristmasDay(DateTime input) => input == GetChristmasDay(input.Year.ToString());

        public static bool IsChristmasEve(DateTime input) => input == GetChristmasEve(input.Year.ToString());

        public static bool IsColumbusDay(DateTime input) => input == GetColumbusDay(input.Year.ToString());

        public static bool IsIndependenceDay(DateTime input) => input == GetIndependenceDay(input.Year.ToString());

        public static bool IsLaborDay(DateTime input) => input == GetLaborDay(input.Year.ToString());

        public static bool IsMartinLutherKingJrDay(DateTime input) => input ==
            GetMartinLutherKingJrDay(input.Year.ToString());

        public static bool IsMemorialDay(DateTime input) => input == GetMemorialDay(input.Year.ToString());

        public static bool IsNewYearsDay(DateTime input) => input == GetNewYearsDay(input.Year.ToString());

        public static bool IsNewYearsEve(DateTime input) => input == GetNewYearsEve(input.Year.ToString());

        public static bool IsPresidentsDay(DateTime input) => input == GetPresidentsDay(input.Year.ToString());

        public static bool IsSpecialDate(DateTime input) => input.IsChristmasDay() ||
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


        public static bool IsThanksgivingDay(DateTime input) => input == GetThanksgivingDay(input.Year.ToString());

        public static bool IsThanksgivingDayAfter(DateTime input) => input ==
            GetThanksgivingDayAfter(input.Year.ToString());

        public static bool IsVeteransDay(DateTime input) => input == GetVeteransDay(input.Year.ToString());

        public static bool IsWeekDay(DateTime input) => !IsWeekEnd(input);

        public static bool IsWeekEnd(DateTime input) => (input.DayOfWeek == DayOfWeek.Saturday ||
            input.DayOfWeek == DayOfWeek.Sunday);
    }
}
