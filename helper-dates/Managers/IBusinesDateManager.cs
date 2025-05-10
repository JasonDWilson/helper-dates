using jwpro.DateHelper.Domain;
using jwpro.DateHelper.Enums;
using System;
using System.Collections.Generic;

namespace jwpro.DateHelper.Managers
{
	public interface IBusinesDateManager
	{
		double GetBusinessHours(DateTime from, DateTime to);

		DateTime? GetPaidHolidayDate(SpecialDate special, string year);

		DateTime? GetPaidHolidayDate(string name, string year);

		bool IsBusinessDay(DateTime input);

		bool IsPaidHoliday(DateTime input);

		List<PaidHoliday> PaidHolidays { get; }
	}
}
