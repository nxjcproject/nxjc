using NXJC.Model.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Service.Messages.ReportForm
{
    public class ReportResponse : ResponseBase
    {
        public IEnumerable<Report> Reports { get; set; }
    }
}
