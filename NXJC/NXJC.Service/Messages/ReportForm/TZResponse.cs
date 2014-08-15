using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Service.Views.ReportForm;

namespace NXJC.Service.Messages.ReportForm
{
    public class TZResponse : ResponseBase
    {
        public IEnumerable<TZView> TZViews { get; set; }
        public TZView TZView { get; set; }
    }
}
