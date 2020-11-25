using jwpro.DateHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Extensions
{
    public static class DateExtensions
    {
        public static IEnumerable<SpecialDates> SpecialDates(this DateTime input)
        {
            List<SpecialDates> result = new List<SpecialDates>();
            foreach(SpecialDates special in Enum.GetValues(typeof(SpecialDates)))
            {
            }
            return result;
        }
    }
}
