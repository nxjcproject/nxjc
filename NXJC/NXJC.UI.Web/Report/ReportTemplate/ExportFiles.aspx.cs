using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Report.ReportTemplate
{
    public partial class ExportFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string m_ExportMethod = Request.Form["myMethod"].ToString();
            string m_ExportData = Request.Form["myData"].ToString();
            if (m_ExportMethod == "OutExcelStream")
            {
                ReportTemplateHelper.OutExcelStream(m_ExportData);
            }


            Response.Write("<script>window.opener=null;window.close();</script>");
        }
    }
}