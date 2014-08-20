﻿using JsonSerialize;
using NXJC.Service.Messages.ReportForm;
using NXJC.Service.Services.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NXJC.UI.Web.Report
{
    /// <summary>
    /// FormulaYearInformationService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class FormulaYearInformationService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetFormulaYearDatas(Guid id)
        {
            FormulaYearRequest request = new FormulaYearRequest
            {
                KeyID = id
            };
            ReportService service = new ReportService();
            FormulaYearResponse response = service.GetFormulaYearByKeyID(request);
            string result = JsonHelper.ObjectToJson(response.FormulaYearViews);
            return result;
        }
        [WebMethod]
        public string GetTZInformations(Guid id)
        {
            TZRequest request = new TZRequest
            {
                KeyID = id
            };
            IReportService service = new ReportService();
            TZResponse response = service.GetTZInformationByKeyID(request);

            string result = JsonHelper.ObjectToJson(response.TZView);
            return result;
        }
    }
}
