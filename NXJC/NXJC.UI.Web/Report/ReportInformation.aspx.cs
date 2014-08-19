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

namespace NXJC.UI.Web.Report
{
    public partial class ReportInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetTZInformation(string reportType,string reportName, string startTime, string endTime)
        {
            TZRequest request = new TZRequest
            {
                EndTime = endTime,
                ReportName = reportName,
                ReportType = reportType,
                StartTime = startTime
            };
            ReportService service = new ReportService();
            TZResponse response = service.GetTZ(request);
            EasyUIJsonTemplate<TZView> jsonclass =new EasyUIJsonTemplate<TZView>
            {
                total = response.TZViews.Count(),
                rows = response.TZViews
            };
            //string result = "{\"total\": 2, \"rows\":" + JsonHelper.ObjectToJson(response.TZViews) + "}";
            string result = JsonHelper.ObjectToJson(jsonclass);
            return result;
        }
    }
}