using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public class DatabaseModel
    {
        public string DatabaseName { get; set; }
        public string IPAddress { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
