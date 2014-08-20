using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Messages.ReportForm
{
    public class TZRequest
    {
        public Guid KeyID { get; set; }
        public string ProductLineName { get; set; }
        public string ReportName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool ModifiedFlag { get; set; }
        public string ReportType { get; set; }
    }
}
