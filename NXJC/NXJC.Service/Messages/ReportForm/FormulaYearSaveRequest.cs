using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Service.Views.ReportForm;

namespace NXJC.Service.Messages.ReportForm
{
    public class FormulaYearSaveRequest
    {
        public TZView TZView { get; set; }
        public IEnumerable<FormulaYearView> FormulaYears { get; set; }
        public IEnumerable<FormulaYearView> DeleteFormulaYears { get; set; }
    }
}
