﻿using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Extensions
{
    public static class DateExtensions
    {
        public static bool IsChristmasDay(this DateTime input) => SpecialDateHelper.IsChristmasDay(input);

        public static bool IsChristmasEve(this DateTime input) => SpecialDateHelper.IsChristmasEve(input);

        public static bool IsColumbusDay(this DateTime input) => SpecialDateHelper.IsColumbusDay(input);

        public static bool IsIndependenceDay(this DateTime input) => SpecialDateHelper.IsIndependenceDay(input);

        public static bool IsLaborDay(this DateTime input) => SpecialDateHelper.IsLaborDay(input);

        public static bool IsMartinLutherKingJrDay(this DateTime input) => SpecialDateHelper.IsMartinLutherKingJrDay(
            input);

        public static bool IsMemorialDay(this DateTime input) => SpecialDateHelper.IsMemorialDay(input);

        public static bool IsNewYearsDay(this DateTime input) => SpecialDateHelper.IsNewYearsDay(input);

        public static bool IsNewYearsEve(this DateTime input) => SpecialDateHelper.IsNewYearsEve(input);

        public static bool IsPresidentsDay(this DateTime input) => SpecialDateHelper.IsPresidentsDay(input);

        public static bool IsSpecialDate(this DateTime input) => SpecialDateHelper.IsSpecialDate(input);

        public static bool IsThanksgivingDay(this DateTime input) => SpecialDateHelper.IsThanksgivingDay(input);

        public static bool IsThanksgivingDayAfter(this DateTime input) => SpecialDateHelper.IsThanksgivingDayAfter(
            input);

        public static bool IsVeteransDay(this DateTime input) => SpecialDateHelper.IsVeteransDay(input);

        public static bool IsWeekDay(this DateTime input) => SpecialDateHelper.IsWeekDay(input);

        public static bool IsWeekEnd(this DateTime input) => SpecialDateHelper.IsWeekEnd(input);

        public static IEnumerable<SpecialDate> SpecialDates(this DateTime input)
        {
            List<SpecialDate> result = new List<SpecialDate>();
            foreach(SpecialDate special in Enum.GetValues(typeof(SpecialDate)))
                if(special != Enums.SpecialDate.Custom && SpecialDateHelper.GetSpecialDate(special, input.Year.ToString()) == input)
                    result.Add(special);
            return result;
        }
    }
}
