using NXJC.Service.Services.ReportForm;
using NXJC.Service.Views.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JsonSerialize;

namespace NXJC.UI.Web.Report
{
    /// <summary> 
    /// ReportInformationService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class ReportInformationService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetReportNames()
        {
            ReportService service = new ReportService();

            IEnumerable<ReportNameView> reportNameViews = service.GetReportNameViews();
            Context.Response.Write(JsonHelper.ObjectToJson(reportNameViews));
        }
    }
}
