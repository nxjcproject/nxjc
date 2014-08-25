﻿using NXJC.Infrastructure.Configuration;
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

namespace NXJC.UI.Web.ProcessTeam
{
    public partial class table_FormulaGroupDayInformation : System.Web.UI.Page
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
                cmd.CommandText = "SELECT [KeyID],[层次码],[工序名称],早班电耗,中班电耗,晚班电耗,合计电耗 FROM [table_FormulaGroupDay]";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            DataGridColumnType columnType = new DataGridColumnType
            {
                ColumnText = new string[] { "ID", "层次码", "工序名称", "早班电耗", "中班电耗", "晚班电耗", "合计电耗" },
                ColumnWidth = new int[] { 10, 50, 60, 60, 60, 60, 60,  },
                ColumnType = new string[] { "", "", "", "", "", "", "",  }
            };

            string result = ReportTemplateHelper.GetDataGridTemplate(dt, columnType);

            return result;
        }
    }
}