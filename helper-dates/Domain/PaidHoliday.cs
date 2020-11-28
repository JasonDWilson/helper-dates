﻿using jwpro.DateHelper.Enums;
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
        private string _name;

        public DateTime? GetDate(string year = null)
        {
            // make sure year is provided
            if(string.IsNullOrWhiteSpace(year))
                year = DateTime.Now.ToString();

            // use related special date as override
            if(RelatedSpecialDate != 0 && RelatedSpecialDate != SpecialDate.Custom)
                DateCalculation = (string y) => SpecialDateHelper.GetSpecialDate(RelatedSpecialDate, y)
                    .AddDays(RelatedSpecialDateOffset);

            if(DateCalculation != null)
                return DateCalculation.Invoke(year);
            else if(AssociatedSpecialDate != SpecialDate.Custom)
                return SpecialDateHelper.GetSpecialDate(AssociatedSpecialDate, year);

            return null;
        }

        public SpecialDate AssociatedSpecialDate { get; set; }

        public Func<string, DateTime> DateCalculation { get; set; }

        public string Name
        {
            get
            {
                if(string.IsNullOrWhiteSpace(_name))
                    _name = AssociatedSpecialDate.ToString().Replace("_", " ");
                return _name;
            }
            set { _name = value; }
        }

        public SpecialDate RelatedSpecialDate { get; set; }

        public int RelatedSpecialDateOffset { get; set; }
    }
}