using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); }
        }
        public string IndustryEnergy_SHConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["IndustryEnergy_SH"].ToString(); }
        }
    }
}
