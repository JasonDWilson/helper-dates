using jwpro.DateHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Managers
{
    public class BusinesDateManager
    {
        BusinessDateManagerConfiguration _config;

        public BusinesDateManager(BusinessDateManagerConfiguration config)
        { _config = config ?? throw new ArgumentNullException(nameof(config)); }
    }
}
