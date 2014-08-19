using NXJC.Service.Views.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Services.ReportForm
{
    public interface IReportFormService : ITZ, IFormulaYear
    {
        IEnumerable<ReportNameView> GetReportNameViews();
    }
}
