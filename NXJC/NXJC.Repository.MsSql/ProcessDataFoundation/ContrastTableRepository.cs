using NXJC.Infrastructure.Configuration;
using NXJC.Model.ProcessDataFoundation;
using NXJC.Model.ProcessDataFoundation.Repository;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NXJC.Repository.ProcessDataFoundation
{
    public class ContrastTableRepository : IContrastTableRepository
    {
        /// <summary>
        /// 获取画面名集合
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetViewNames(int productLineId)
        {
            string connectionString = ConnectionStringFactory.GetByProductLineId(productLineId);

            IDictionary<string, string> result = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT DISTINCT ViewName FROM dbo.ContrastTable";

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string viewName = reader[0].ToString().Trim();
                        result.Add(viewName, viewName);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获得视图变量路径信息
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public IEnumerable<DataPathInformation> GetDataPaths(int productLineId, string viewName)
        {
            string connectionString = ConnectionStringFactory.GetByProductLineId(productLineId);
            ISqlServerDataFactory dataFactory = new SqlServerDataFactory(connectionString);

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
        public System.Collections.ArrayList GetVariableId(int productLineId, string viewName)
        {
            string connectionString = ConnectionStringFactory.GetByProductLineId(productLineId);
            ISqlServerDataFactory dataFactory = new SqlServerDataFactory(connectionString);

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
