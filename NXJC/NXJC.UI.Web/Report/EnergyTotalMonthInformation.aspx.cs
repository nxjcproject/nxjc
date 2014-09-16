using NXJC.Infrastructure.Configuration;
using NXJC.UI.Web.Report.ReportTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Report
{
    public partial class EnergyTotalMonth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetTreeGridDatas()
        {
            string connString = ConnectionStringFactory.NXJCConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, [名称], [生料制备1], [熟料烧成1], [水泥制备1], [用煤量], [生料制备2], [熟料烧成2], [水泥制备2], [发电量], [生料制备3], [熟料烧成], [水泥制备], [吨熟料综合电耗], [吨熟料实物煤耗], [吨熟料发电量], [_parentId]  FROM [EnergyTotalMonth]";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            string[] column = { "ID", "名称", "生料制备1", "熟料烧成1", "水泥制备1", "用煤量", "生料制备2", "熟料烧成2", "水泥制备2", "发电量", "生料制备3", "熟料烧成", "水泥制备", "吨熟料综合电耗", "吨熟料实物煤耗", "吨熟料发电量", "_parentId" };
            string result = ReportTemplateHelper.DataTableToJson(dt, column);

            return result;
        }
    }
}