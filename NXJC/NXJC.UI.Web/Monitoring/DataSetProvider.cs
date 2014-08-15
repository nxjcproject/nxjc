using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServerDataAdapter.Infrastruction;
using SqlServerDataAdapter;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using NXJC.Model.Monitoring;

namespace NXJC.UI.Web.Monitoring
{
    public class DataSetProvider
    {
        ISqlServerDataFactory dataFactory;

        public DataSetProvider(string connectionString)
        {
            dataFactory = new SqlServerDataFactory(connectionString); 
        }

        /// <summary>
        /// 获得DataSetInformation
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private IEnumerable<DataSetInformation> GetDataSetInformation(string viewName)
        {
            IList<DataSetInformation> results = new List<DataSetInformation>();
            Query query = new Query("ContrastTable");
            query.AddCriterion("ViewName", "viewName", viewName, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(query);
            foreach (DataRow item in table.Rows)
            {
                results.Add(new DataSetInformation
                {
                    ViewId = item["VariableName"].ToString().Trim(),
                    FieldName = item["FieldName"].ToString().Trim(),
                    TableName = item["TableName"].ToString().Trim()
                });
            }
            return results;
        }

        private DataItem GetDataItem(DataSetInformation dataSetInformation)
        {
            DataItem result = new DataItem();
            ComplexQuery cmpquery = new ComplexQuery();
            cmpquery.AddNeedField(dataSetInformation.TableName, dataSetInformation.FieldName, dataSetInformation.FieldName);
            cmpquery.TopNumber = TopNumber.top1;
            cmpquery.OrderByClause = new OrderByClause("v_date", true);
            DataTable table = dataFactory.Query(cmpquery);

            foreach(DataRow item in table.Rows)
            {
                result = new DataItem
                {
                    ID = dataSetInformation.ViewId,
                    Value = item[dataSetInformation.FieldName].ToString().Trim()
                };
            }
            return result;
        }

        /// <summary>
        /// 获得实时数据的table表
        /// </summary>
        /// <param name="dataSetInformations"></param>
        /// <returns></returns>
        private DataTable GetDataItemTable(IEnumerable<DataSetInformation> dataSetInformations)
        {
            //DataItem result = new DataItem();
            ComplexQuery cmpquery = new ComplexQuery();
            foreach (var item in dataSetInformations)
            {
                cmpquery.AddNeedField(item.TableName, item.FieldName, item.ViewId);
            }
            cmpquery.JoinCriterion = new JoinCriterion
            {
                JoinFieldName = "v_date",
                JoinType = JoinType.FULL_JOIN
            };
            cmpquery.TopNumber = TopNumber.top1;
            //cmpquery.OrderByClause = new OrderByClause("realtime_line_data.v_date", true);
            DataTable table = dataFactory.Query(cmpquery);

            return table;
        }
        /// <summary>
        /// 获得实时视图数据
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public IEnumerable<DataItem> GetRealtimeDatas(string viewName)
        {
            IList<DataItem> result = new List<DataItem>();
            ArrayList idList = GetParametorsId(viewName);
            IEnumerable<DataSetInformation> dataSetInfor = GetDataSetInformation(viewName);
            DataTable table = GetDataItemTable(dataSetInfor);
            foreach (var item in idList)
            {
                result.Add(new DataItem
                {
                    ID = item.ToString().Trim(),
                    Value = table.Rows[0][item.ToString().Trim()].ToString().Trim()
                });
            }
            return result;
        }

        /// <summary>
        /// 返回最近两天的历史数据表
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private DataTable GetHistoryDataTable(string viewName)
        {
            bool flag = false;
            DataTable result = new DataTable();
            IList<NeedField> needFields = new List<NeedField>();
            IEnumerable<DataSetInformation> dataSetInfor = GetDataSetInformation(viewName);
            foreach (var item in dataSetInfor)
            {
                if (flag == false)
                {
                    needFields.Add(new NeedField
                    {
                        FieldName = "v_date",
                        TableName = item.TableName,
                        VariableName = "date"
                    });
                    flag = true;
                }

                needFields.Add(new NeedField
                {
                    FieldName = item.FieldName,
                    TableName = item.TableName,
                    VariableName = item.ViewId
                });
            }
            JoinCriterion joinCriterion = new JoinCriterion
            {
                JoinFieldName = "v_date",
                JoinType = JoinType.FULL_JOIN
            };
            ComplexQuery cmpquery = new ComplexQuery(needFields,joinCriterion);
            //cmpquery.AddCriterion("v_date", DateTime.Now.AddDays(1).Date, CriteriaOperator.LessThan);
            //cmpquery.AddCriterion("v_date", DateTime.Now.AddDays(-1).Date, CriteriaOperator.MoreThan);
            result = dataFactory.Query(cmpquery);

            return result;
        }

        /// <summary>
        /// 获得视图中所有变量的Id值
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private ArrayList GetParametorsId(string viewName)
        {
            ArrayList result = new ArrayList();
            ComplexQuery cmpquery = new ComplexQuery();
            cmpquery.AddNeedField("ContrastTable", "VariableName");
            cmpquery.AddCriterion("ViewName", viewName, CriteriaOperator.Equal);
            DataTable data = dataFactory.Query(cmpquery);
            foreach (DataRow row in data.Rows)
            {
                result.Add(row["VariableName"].ToString().Trim());
            }
            return result;
        }

        /// <summary>
        /// 获得历史数据和Id集合
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public HistoryData GetHistoryData(string viewName)
        {
            DataTable dataTable = GetHistoryDataTable(viewName);
            ArrayList idList = GetParametorsId(viewName);
            return new HistoryData
            {
                IdArray = idList,
                Datas = dataTable
            };
        }
    }

    public class DataSetInformation
    {
        public string ViewId { get; set; }
        public string FieldName { get; set; }
        public string TableName { get; set; }
    }

    [Serializable]
    public class HistoryData
    {
        public ArrayList IdArray { get; set; }
        public DataTable Datas { get; set; }

        public HistoryData()
        {
            IdArray = new ArrayList();
            Datas = new DataTable();
        }
    }
}