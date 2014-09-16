using NXJC.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Monitoring
{
    public partial class Realtime : System.Web.UI.Page
    {
        public int ProductLineId { get; set; }
        public string SceneName { get; set; }
        public string TemplatePath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int productLineId = 0;
            try
            {
                productLineId = int.Parse(Request["productLineId"]);
            }
            catch
            {
            }

            string templateFolder = ConnectionStringFactory.GetCatalogNameByProductLineID(productLineId, DatabaseType.DCSSystemDatabase);
            ProductLineId = productLineId;
            SceneName = Request["viewName"];
            TemplatePath = "/Monitoring/Templates/" + templateFolder + "/" + SceneName + "/template.html";
        }
    }
}