using NXJC.Service.Messages.ReportForm;
using NXJC.Service.Views.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Service.Services.ReportForm
{
    public interface IReportService
    {
        TZResponse GetTZ(TZRequest request);

        IEnumerable<ReportNameView> GetReportNameViews();

        FormulaYearResponse GetFormulaYearByKeyID(FormulaYearRequest request);

        TZResponse GetTZInformationByKeyID(TZRequest request);

        ReportResponse GetRepoersByType(ReportRequest request);
    }
}
