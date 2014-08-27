using NXJC.Infrastructure.Configuration;
using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using NXJC.Model.ProcessDataFoundation;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Repository.Monitoring
{
    public class RealtimeRepository : IRealtimeRepository
    {
        public SceneMonitor GetLatest(string sceneName)
        {
            SceneMonitor sceneMonitor = new SceneMonitor();
            sceneMonitor.Id = DateTime.Now;
            sceneMonitor.Name = sceneName;

            Random random = new Random();
            IList<DataItem> dataSet = new List<DataItem>();
            for (int i = 1; i <= 4; i++)
            {
                dataSet.Add(new DataItem()
                {
                    ID = "test" + i,
                    Value = random.NextDouble().ToString()
                });
            }

            sceneMonitor.DataSet = dataSet;

            return sceneMonitor;
        }

        /// <summary>
        /// 获得实时数据的table表
        /// </summary>
        /// <param name="dataPathInfor"></param>
        /// <returns></returns>
        public DataTable GetDataItemTable(int productLineId, IEnumerable<DataPathInformation> dataPathInfor)
        {
            string connectionString = ConnectionStringFactory.GetByProductLineId(productLineId);
            ISqlServerDataFactory dataFactory = new SqlServerDataFactory(connectionString);

            ComplexQuery cmpquery = new ComplexQuery();
            foreach (var item in dataPathInfor)
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
    }
}
