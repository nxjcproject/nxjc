using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string NXJCConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ManagementData"].ToString(); }
        }

        public string IndustryEnergy_SHConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["IndustryEnergy_SH"].ToString(); }
        }


        public string Db_01_WastedHeatPowerConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Db_01_WastedHeatPower"].ToString(); }
        }


        public string ProcessDataConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ProcessData"].ToString(); }
        }
    }
}
