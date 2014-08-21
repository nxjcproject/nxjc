using DataTypeConvert;
using NXJC.Repository.ReportForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NXJC.UI.Web.Report.ReportTemplate
{
    public class ReportTemplateHelper
    {
        public static ReportDataHelper dataHelper = new ReportDataHelper();
        private static readonly ExportFileForWeb.ExportExcel Extend_ExportExcel = new ExportFileForWeb.ExportExcel();

        public static string GetFormulaYearReportTemplate(DataTable table)
        {
            string m_ValidTreeJson = "";
            string[] m_ColumnText = new string[] { "KeyID", "number", "Energy" };
            int[] m_ColumnWidth = new int[] { 180, 230, 130 };
            string[] m_FormatString = new string[] { "", "\"type\":\"text\"", "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}" };//"\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", "", "", "\"type\":\"checkbox\", \"options\":{\"on\":\"True\",\"off\":\"False\"}", "\"type\":\"text\"" };

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
    }
}