using NXJC.Infrastructure.Configuration;
using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NXJC.Repository.Monitoring
{
    public class ContrastTableRepository : IContrastTableRepository
    {
        ISqlServerDataFactory dataFactory;

        public ContrastTableRepository()
        {
            string connectionString = ApplicationSettingsFactory.GetApplicationSettings().Db_01_WastedHeatPowerConnectionString;
            dataFactory = new SqlServerDataFactory(connectionString);
        }

        /// <summary>
        /// 获得视图变量路径信息
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public IEnumerable<DataPathInformation> GetDataPaths(string viewName)
        {
            IList<DataPathInformation> results = new List<DataPathInformation>();
            Query query = new Query("ContrastTable");
            query.AddCriterion("ViewName", "viewName", viewName, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(query);
            foreach (DataRow item in table.Rows)
            {
                results.Add(new DataPathInformation
                {
                    ViewId = item["VariableName"].ToString().Trim(),
                    FieldName = item["FieldName"].ToString().Trim(),
                    TableName = item["TableName"].ToString().Trim()
                });
            }
            return results;
        }

        /// <summary>
        /// 获得视图中所有变量的Id值
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public System.Collections.ArrayList GetVariableId(string viewName)
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
    }
}
