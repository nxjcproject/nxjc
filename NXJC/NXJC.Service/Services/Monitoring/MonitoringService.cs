using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using NXJC.Repository.Monitoring;
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
        IContrastTableRepository contrastTableRepository;
        IRealtimeRepository realtimeRepository;

        public MonitoringService()
        {
            contrastTableRepository = new ContrastTableRepository();
            realtimeRepository = new RealtimeRepository();
        }

        /// <summary>
        /// 获得视图实时数据
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public IEnumerable<Model.Monitoring.DataItem> GetRealtimeDataItems(string viewName)
        {
            IList<DataItem> result = new List<DataItem>();
            ArrayList idList = contrastTableRepository.GetVariableId(viewName);
            IEnumerable<DataPathInformation> dataPathInfor = contrastTableRepository.GetDataPaths(viewName);
            DataTable table = realtimeRepository.GetDataItemTable(dataPathInfor);
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
    }
}
