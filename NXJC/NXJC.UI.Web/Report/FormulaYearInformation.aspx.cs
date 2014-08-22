using NXJC.Service.Messages.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Report
{
    public partial class FormulaYearInformation : System.Web.UI.Page
    {
        //private Guid id;
        //private string _tableName;
        public Guid KeyID
        {
            get { return (Guid)ViewState["id"]; }
            set { ViewState["id"] = value; }
        }
        public string TableName
        {
            get { return ViewState["tablename"].ToString(); }
            set { ViewState["tablename"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            KeyID =  Guid.Parse(Request.QueryString["id"]);
            TableName = Request.QueryString["tablename"].ToString();
        }
    }
}