using jwpro.DateHelper.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Configuration
{
    public class BusinessDateManagerConfiguration
    {
        public List<PaidHoliday> PaidHolidays { get; set; } = new List<PaidHoliday>();
    }
}
