using JsonSerialize;
using NXJC.Model.ReportForm;
using NXJC.Repository.ReportForm;
using NXJC.Service.Messages.ReportForm;
using NXJC.Service.Services.ReportForm;
using NXJC.Service.Views.ReportForm;
using NXJC.UI.Web.Report.ReportTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Services;
using NXJC.Service.Mappers.ReportForm;

namespace NXJC.UI.Web.Report
{
    /// <summary>
    /// FormulaYearInformationService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class FormulaYearInformationService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetFormulaYearDatas(Guid id)
        {
            FormulaYearRequest request = new FormulaYearRequest
            {
                KeyID = id
            };
            ReportService service = new ReportService();
            FormulaYearResponse response = service.GetFormulaYearByKeyID(request);
            string result = JsonHelper.ObjectToJson(response.FormulaYearViews);
            return result;
        }
        [WebMethod]
        public string GetTZInformations(Guid id)
        {
            TZRequest request = new TZRequest
            {
                KeyID = id
            };
            IReportService service = new ReportService();
            TZResponse response = service.GetTZInformationByKeyID(request);

            string result = JsonHelper.ObjectToJson(response.TZView);
            return result;
        }
        /*************************************************************************************/
        [WebMethod]
        public string GetFormulaYearTemplateData(Guid id, string tableName)
        {
            ReportDataHelper dataHelper = new ReportDataHelper();
            DataTable dt = dataHelper.GetFormulaYearTable(id, tableName);
            DataGridColumnType columnType = new DataGridColumnType
            {
                ColumnText = new string[] { "KeyID","序号", "层次码", "工序名称", "峰期电耗", "尖峰期电耗", "谷期电耗", "平期电耗", "总计" },
                ColumnWidth = new int[] { 80,130 , 130, 130, 130, 130, 130, 130, 130 },
                ColumnType = new string[] { "", "\"type\":\"text\"","\"type\":\"text\"", "\"type\":\"text\"",
                "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}", 
                "\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}","\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}","\"type\":\"numberbox\", \"options\":{\"precision\":\"2\"}" }
            };
            return ReportTemplateHelper.GetDataGridTemplate(dt, columnType);
        }

        [WebMethod]
        public string ChangeDataByGrid(string myJsonData, string tableName)
        {
            string m_GridJson = myJsonData;
            DataContractJsonSerializer m_JsonDs = new DataContractJsonSerializer(typeof(ReportDataGroup<NXJC.Model.ReportForm.FormulaYear,TZView>));
            MemoryStream m_JsonStringMs = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(myJsonData));
            ReportDataGroup<NXJC.Model.ReportForm.FormulaYear,TZView> m_ReportDataGroup = (ReportDataGroup<NXJC.Model.ReportForm.FormulaYear,TZView>)m_JsonDs.ReadObject(m_JsonStringMs);

            ReportDataHelper dataHelper = new ReportDataHelper();
            string result = dataHelper.ChangeFormulaYear(tableName,m_ReportDataGroup.deleted, m_ReportDataGroup.updated, m_ReportDataGroup.inserted);

            return "1";
        }

        [WebMethod]
        public string SaveAnotherByGrid(string myJsonData, string tableName)
        {
            string m_GridJson = myJsonData;

            //DataContractJsonSerializer m_JsonDs = new DataContractJsonSerializer(typeof(ReportDataSaveAnother<FormulaYear, TZView>));
            //MemoryStream m_JsonStringMs = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(myJsonData));
            //ReportDataSaveAnother<FormulaYear, TZView> m_ReportDataGroup = (ReportDataSaveAnother<FormulaYear, TZView>)m_JsonDs.ReadObject(m_JsonStringMs);
            try
            {
                ReportDataSaveAnother<FormulaYear, TZView> saveAnotherObject = (ReportDataSaveAnother<FormulaYear, TZView>)JsonHelper.JsonToObject(m_GridJson, new ReportDataSaveAnother<FormulaYear, TZView>());
                TZ tzValue = saveAnotherObject.TzValue.FirstOrDefault().ConvertToTz();
                tzValue.Version = DateTime.Now;

                ReportDataHelper dataHelper = new ReportDataHelper();
                string result = dataHelper.SaveAnotherFormulaYear(tableName, saveAnotherObject.ChildrenValue, tzValue);

                return result;
            }
            catch
            {
                return "-1";
            }
        }
    }
}
