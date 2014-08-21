using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Views.ReportForm
{
    //[DataContract]
    public class TZView
    {
        public int ProductLineID { get; set; }
        public string ProductLineName { get; set; }
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string Date { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? Version { get; set; }
        public string ModifierID { get; set; }
        public string ModifierName { get; set; }
        public bool ModifiedFlag { get; set; }
        public string Remarks { get; set; }
        public Guid KeyID { get; set; } 

        public string ReportCreationDate
        {
            get { return String.Format("{0:yyyy-MM-dd}", CreationDate); }
        }

        public string VersionDate
        {
            get { return String.Format("{0:yyyy-MM-dd}", Version); }
        }
    }
}
