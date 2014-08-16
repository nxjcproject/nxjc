using NXJC.Model.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Services.Monitoring
{
    public interface IMonitoringService
    {
        /// <summary>
        /// 获得视图实时数据
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        IEnumerable<DataItem> GetRealtimeDataItems(string viewName);
    }
}
