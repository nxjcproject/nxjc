using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Monitoring
{
    public partial class Views : System.Web.UI.Page
    {
        private const string CONNECTION_STRING = "Data Source=DEC-WINSVR12;Initial Catalog=Db_01_WastedHeatPower;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";

        public Dictionary<string, string> DisplayNameDictionary = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string productionLineName = Request.QueryString["productionLineName"];

            // todo: 检索 productionLine 是否存在

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT DISTINCT ViewName FROM dbo.ContrastTable";

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string viewName = reader[0].ToString().Trim();
                        DisplayNameDictionary.Add(viewName, GetDisplayName(viewName));
                    }
                }
            }
        }

        private string GetDisplayName(string viewName)
        {
            switch (viewName)
            {
                case "BoilerSmokeSystem":
                    return "画面1";
                case "BoilerSteamSystem":
                    return "画面2";
                case "HeatExchangeStation":
                    return "画面3";
                case "TurbineGeneralAppearance":
                    return "画面4";
                case "TurbineLubeOilSystem":
                    return "画面5";
                case "WaterSupplySystem":
                    return "画面6";
                default:
                    throw new ApplicationException("没有此画面");
            }
        }
    }
}