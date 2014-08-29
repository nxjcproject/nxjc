using DataTypeConvert;
using NXJC.Repository.ReportForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace NXJC.UI.Web.Report.ReportTemplate
{
    public class ReportTemplateHelper
    {
        //public static ReportDataHelper dataHelper = new ReportDataHelper();
        private static readonly ExportFileForWeb.ExportExcel Extend_ExportExcel = new ExportFileForWeb.ExportExcel();

        public static string GetFormulaYearReportTemplate(DataTable table)
        {
            string m_ValidTreeJson = "";
            string[] m_ColumnText = new string[] { "KeyID", "Number", "层次码", "工序名称", "峰期电耗", "尖峰期电耗", "谷期电耗", "平期电耗", "总计" };
            int[] m_ColumnWidth = new int[] { 80, 230, 130, 130, 130, 130, 130, 130, 130 };
            string[] m_FormatString = new string[] { "", "\"type\":\"text\"", "\"type\":\"text\"", "\"type\":\"text\"",
                "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", 
                "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}","\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}","\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}" };//"\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", "", "", "\"type\":\"checkbox\", \"options\":{\"on\":\"True\",\"off\":\"False\"}", "\"type\":\"text\"" };

            DataTable m_DataTableUserInfo = table;
            List<Model_GridColumnType> m_Model_GridColumnTypeList = new List<Model_GridColumnType>(1);

            for (int i = 0; i < m_DataTableUserInfo.Columns.Count; i++)
            {
                Model_GridColumnType m_Model_GridColumnType = new Model_GridColumnType();
                m_Model_GridColumnType.ColumnText = m_ColumnText[i];
                m_Model_GridColumnType.ColumnWidth = m_ColumnWidth[i];
                m_Model_GridColumnType.FormatString = m_FormatString[i];
                m_Model_GridColumnTypeList.Add(m_Model_GridColumnType);
            }
            m_ValidTreeJson = DataTableConvertJson.DataTableToJson(m_DataTableUserInfo, m_Model_GridColumnTypeList);
            return m_ValidTreeJson;
        }

        public static void OutExcelStream(string myJsonData)
        {
            Extend_ExportExcel.OutExcelStream(myJsonData);
        }

        public static string GetDataGridTemplate(DataTable table, DataGridColumnType columns)
        {
            string m_ValidTreeJson = "";
            string[] m_ColumnText = columns.ColumnText;// = new string[] { "KeyID", "number", "Energy" };
            int[] m_ColumnWidth = columns.ColumnWidth;// = new int[] { 180, 230, 130 };
            string[] m_FormatString = columns.ColumnType;// = new string[] { "", "\"type\":\"text\"", "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}" };//"\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", "", "", "\"type\":\"checkbox\", \"options\":{\"on\":\"True\",\"off\":\"False\"}", "\"type\":\"text\"" };


            DataTable m_DataTableUserInfo = table;
            List<Model_GridColumnType> m_Model_GridColumnTypeList = new List<Model_GridColumnType>(1);

            for (int i = 0; i < m_DataTableUserInfo.Columns.Count; i++)
            {
                Model_GridColumnType m_Model_GridColumnType = new Model_GridColumnType();
                m_Model_GridColumnType.ColumnText = m_ColumnText[i];
                m_Model_GridColumnType.ColumnWidth = m_ColumnWidth[i];
                m_Model_GridColumnType.FormatString = m_FormatString[i];
                m_Model_GridColumnTypeList.Add(m_Model_GridColumnType);
            }
            m_ValidTreeJson = DataTableConvertJson.DataTableToJson(m_DataTableUserInfo, m_Model_GridColumnTypeList);
            return m_ValidTreeJson;
        }

        /// <summary>
        /// datatable 转化为 json
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnsToParse"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable table, params string[] columnsToParse)
        {
            if (table == null || table.Rows.Count == 0)
                return "{\"total\":0,\"rows\":[]}";

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"total\":").Append(table.Rows.Count).Append(",");
            sb.Append("\"rows\":[");

            foreach (DataRow row in table.Rows)
            {
                sb.Append("{");

                foreach (string column in columnsToParse)
                {
                    sb.Append("\"").Append(column).Append("\":").Append("\"").Append(row[column].ToString().Trim()).Append("\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");

            return sb.ToString();
        }
    }

    public class DataGridColumnType
    {
        public string[] ColumnText { get; set; }
        public int[] ColumnWidth { get; set; }
        public string[] ColumnType { get; set; }
    }
}