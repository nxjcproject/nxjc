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

namespace NXJC.UI.Web.PeakValleyFlat
{
    public partial class table_ammeter_summit_low_flat_month : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetCompanyData()
        {
            string connString = ConnectionStringFactorytenp.GetNXJCConnectionString();   //填写链接字符串
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT  KeyId,编号,设备名,峰期电耗,谷期电耗,平期电耗,合计电耗 FROM table_AmmeterSummitLowFlatMonth";                          //填写查询语句
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            DataGridColumnType columnType = new DataGridColumnType
            {
                ColumnText = new string[] { "ID", "编号", "设备名", "峰期电耗","谷期电耗", "平期电耗", "合计电耗" },                                 //填写表头及宽度
                ColumnWidth = new int[] { 10, 100, 100, 100, 100,100, 100 },
                ColumnType = new string[] { "", "", "", "", "", "", "" }
            };

            string result = ReportTemplateHelper.GetDataGridTemplate(dt, columnType);

            return result;
        }
    }
}