using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Exceptions;
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

        public static DateTime GetSpecialDate(SpecialDates special, string year)
        {
            switch(special)
            {
                case SpecialDates.Christmas_Day:
                    return SpecialDateHelper.GetChristmasDay(year);
                case SpecialDates.Christmas_Eve:
                    return SpecialDateHelper.GetChristmasEve(year);
                case SpecialDates.Columbus_Day:
                    return SpecialDateHelper.GetColumbusDay(year);
                case SpecialDates.Independence_Day:
                    return SpecialDateHelper.GetIndependenceDay(year);
                case SpecialDates.Labor_Day:
                    return SpecialDateHelper.GetLaborDay(year);
                case SpecialDates.Martin_Luther_King_Jr_Day:
                    return SpecialDateHelper.GetMartinLutherKingJrDay(year);
                case SpecialDates.Memorial_Day:
                    return SpecialDateHelper.GetMemorialDay(year);
                case SpecialDates.New_Years_Day:
                    return SpecialDateHelper.GetNewYearsDay(year);
                case SpecialDates.New_Years_Eve:
                    return SpecialDateHelper.GetNewYearsEve(year);
                default:
                    throw new NotSupportedSpecialDateException($"{special} is not a currently supported special date");
            }
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
    }
}
