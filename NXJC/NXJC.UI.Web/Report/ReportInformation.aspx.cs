using NXJC.Service.Messages.ReportForm;
using NXJC.Service.Services.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using JsonSerialize;
using NXJC.Service.Views.ReportForm;
using NXJC.Service.Mappers.ReportForm;

namespace NXJC.UI.Web.Report
{
    public partial class ReportInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetTZInformation(string reportType, string reportName, string modifiedFlag, string startTime, string endTime)
        {
            TZRequest request = new TZRequest
            {
                EndTime = endTime,
                ReportName = reportName,
                ReportType = reportType,
                StartTime = startTime,
                ModifiedFlag = modifiedFlag
            };
            ReportService service = new ReportService();
            TZResponse response = service.GetTZ(request);
            EasyUIJsonTemplate<TZView> jsonclass =new EasyUIJsonTemplate<TZView>
            {
                total = response.TZViews.Count(),
                rows = response.TZViews
            };
            
            string result = JsonHelper.ObjectToJson(jsonclass);
            return result;
        }

        [WebMethod]
        public static string GetReportName(string reportTypeId)
        {
            ReportRequest request = new ReportRequest
            {
                ReportType = int.Parse(reportTypeId)
            };
            ReportService service = new ReportService();
            ReportResponse response = service.GetRepoersByType(request);

            IEnumerable<ReportNameView> reportName = response.Reports.ConvertToReportNameViews();

            string result = JsonHelper.ObjectToJson(reportName);

            return result;
        }
    }
}