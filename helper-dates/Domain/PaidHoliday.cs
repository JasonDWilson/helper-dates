using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Domain
{
    public class PaidHoliday
    {
        public DateTime? GetDate(string year = null)
        {
            // make sure year is provided
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.ToString();

            // use related special date as override
            if(RelatedSpecialDate != null && RelatedSpecialDate != SpecialDate.Custom)
                DateCalculation = (string y) => SpecialDateHelper.GetSpecialDate((SpecialDate)RelatedSpecialDate, y)
                    .AddDays(RelatedSpecialDateOffset);

            if(DateCalculation != null)
                return DateCalculation.Invoke(year);
            else if(SpecialDate != SpecialDate.Custom)
                return SpecialDateHelper.GetSpecialDate(SpecialDate, year);

            return null;
        }

        public Func<string, DateTime> DateCalculation { get; set; }

        public string Name { get; set; }

        public SpecialDate? RelatedSpecialDate { get; set; }

        public int RelatedSpecialDateOffset { get; set; }

        public SpecialDate SpecialDate { get; set; }
    }
}
