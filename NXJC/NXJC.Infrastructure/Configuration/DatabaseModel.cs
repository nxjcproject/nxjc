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
        public int Type { get; set; }

        public override bool Equals(object obj)
        {
            if (((DatabaseModel)obj).DatabaseName == this.DatabaseName && ((DatabaseModel)obj).IPAddress == this.IPAddress &&
                ((DatabaseModel)obj).UserID == this.UserID && ((DatabaseModel)obj).Password == this.Password && ((DatabaseModel)obj).Type == this.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
