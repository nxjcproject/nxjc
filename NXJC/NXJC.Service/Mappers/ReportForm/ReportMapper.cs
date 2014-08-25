using NXJC.Model.ReportForm;
using NXJC.Service.Views.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Service.Mappers.ReportForm
{
    public static class ReportMapper
    {
        public static ReportNameView ConvertToReportNameView(this Report report)
        {
            return new ReportNameView
            {
                ID = report.ID,
                Name = report.Name
            };
        }

        public static IEnumerable<ReportNameView> ConvertToReportNameViews(this IEnumerable<Report> reports)
        {
            IList<ReportNameView> results = new List<ReportNameView>();
            foreach (var item in reports)
            {
                results.Add(item.ConvertToReportNameView());
            }
            return results;
        }
    }
}
