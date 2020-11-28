using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace jwpro.DateHelper.Managers
{
    public class BusinesDateManager
    {
        BusinessDateManagerConfiguration _config;

        public BusinesDateManager(BusinessDateManagerConfiguration config)
        { _config = config ?? throw new ArgumentNullException(nameof(config)); }

        public bool IsPaidHoliday(DateTime input)
        {
            foreach(var holiday in _config.PaidHolidays)
                if(holiday.GetDate(input.Year.ToString()) == input)
                    return true;
            return false;
        }

        public List<PaidHoliday> PaidHolidays { get { return _config.PaidHolidays; } }
    }
}
