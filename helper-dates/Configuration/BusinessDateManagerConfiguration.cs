using jwpro.DateHelper.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Configuration
{
    public class BusinessDateManagerConfiguration
    {
        private string _businessDayBegin;
        private string _businessDayEnd;

        private bool IsMilitaryTime(string time) { return Regex.IsMatch(time, @"([01]\d | 2[0 - 3])[0 - 5]\d"); }

        public string BusinessDayBegin
        {
            get => _businessDayBegin;
            set
            {
                if(!string.IsNullOrWhiteSpace(value) && !IsMilitaryTime(value))
                    throw new ArgumentException("BusinessDayBegin must be a string in military time");
                _businessDayBegin = value;
            }
        }

        public string BusinessDayEnd
        {
            get => _businessDayEnd;
            set
            {
                if(!string.IsNullOrWhiteSpace(value) && !IsMilitaryTime(value))
                    throw new ArgumentException("BusinessDayEnd must be a string in military time");
                _businessDayEnd = value;
            }
        }

        public List<PaidHoliday> PaidHolidays { get; set; } = new List<PaidHoliday>();
    }
}
