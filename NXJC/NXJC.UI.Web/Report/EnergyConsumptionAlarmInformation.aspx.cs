using NXJC.Infrastructure.Configuration;
using NXJC.UI.Web.Report.ReportTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Report
{
    public partial class table_EnergyConsumptionAlarm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetCompanyData()
        {
            string connString = ConnectionStringFactory.GetNXJCConnectionString();   //填写链接字符串
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT KeyID,StartTime,[TimeSpan],Name,StandardValue,ActualValue,Superscale, Reason FROM [EnergyConsumptionAlarm]";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            DataGridColumnType columnType = new DataGridColumnType
            {
                ColumnText = new string[] { "ID", "报警起始时间", "报警范围", "报警设备名称", "标准值", "实际值", "超出范围", "报警原因" },
                ColumnWidth = new int[] { 10, 130, 220, 80, 80, 80, 80, 80 },
                ColumnType = new string[] { "", "", "", "", "", "", "","" }
            };

            string result = ReportTemplateHelper.GetDataGridTemplate(dt, columnType);

            return result;
        }
    }
}