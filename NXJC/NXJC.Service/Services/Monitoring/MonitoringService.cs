using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using NXJC.Model.ProcessDataFoundation;
using NXJC.Model.ProcessDataFoundation.Repository;
using NXJC.Repository.Monitoring;
using NXJC.Repository.ProcessDataFoundation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Services.Monitoring
{
    public class MonitoringService : IMonitoringService
    {
        IContrastTableRepository contrastTableRepository = new ContrastTableRepository();
        IRealtimeRepository realtimeRepository = new RealtimeRepository();

        /// <summary>
        /// 获得视图实时数据
        /// </summary>
        /// <param name="productLineId"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public IEnumerable<DataItem> GetRealtimeDataItems(int productLineId, string viewName)
        {
            IList<DataItem> result = new List<DataItem>();
            ArrayList idList = contrastTableRepository.GetVariableId(productLineId, viewName);
            IEnumerable<DataPathInformation> dataPathInfor = contrastTableRepository.GetDataPaths(productLineId, viewName);
            DataTable table = realtimeRepository.GetDataItemTable(productLineId, dataPathInfor);
            foreach (var item in idList)
            {
                if (table.Rows[0][item.ToString().Trim()].ToString() == "True" || table.Rows[0][item.ToString().Trim()].ToString() == "False")
                {
                    result.Add(new DataItem
                    {
                        ID = item.ToString().Trim(),
                        Value = (table.Rows[0][item.ToString().Trim()].ToString() == "True") ? "1" : "0"
                    });
                }
                else
                {
                    result.Add(new DataItem
                    {
                        ID = item.ToString().Trim(),
                        Value = table.Rows[0][item.ToString().Trim()].ToString().Trim()
                    });
                }
            }
            return result;
        }
    }
}
