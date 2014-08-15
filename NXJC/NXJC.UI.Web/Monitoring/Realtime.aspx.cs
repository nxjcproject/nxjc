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
        public string ProductionLine { get; set; }
        public string SceneName { get; set; }
        public string TemplatePath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductionLine = Request["productionLine"];
            SceneName = Request["viewName"];
            TemplatePath = "/Monitoring/Templates/Db_01_WastedHeatPower/" + SceneName + "/template.html";
        }
    }
}