using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Service.Views.ReportForm;

namespace NXJC.Service.Messages.ReportForm
{
    public class FormulaYearResponse : ResponseBase
    {
        public TZView TZView { get; set; }
        public IList<FormulaYearView> FormulaYearViews { get; set; }
    }
}
