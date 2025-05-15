using jwpro.DateHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace jwpro.DateHelper.Configuration
{
	public class BusinessDateManagerConfiguration
	{
		private string _businessDayBegin;
		private string _businessDayEnd;

		private bool IsMilitaryTime(string time)
		{ return Regex.IsMatch(time, @"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"); }

		public string BusinessDayBegin
		{
			get { return _businessDayBegin; }
			set
			{
				if(!string.IsNullOrWhiteSpace(value) && !IsMilitaryTime(value))
				{
					throw new ArgumentException("BusinessDayBegin must be a string in military time");
				}

				_businessDayBegin = value;
			}
		}

		public string BusinessDayEnd
		{
			get { return _businessDayEnd; }
			set
			{
				if(!string.IsNullOrWhiteSpace(value) && !IsMilitaryTime(value))
				{
					throw new ArgumentException("BusinessDayEnd must be a string in military time");
				}

				_businessDayEnd = value;
			}
		}

		public List<PaidHoliday> PaidHolidays { get; set; }
	}
}
