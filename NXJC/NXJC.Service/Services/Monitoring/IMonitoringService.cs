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
        IEnumerable<DataItem> GetRealtimeDataItems(string viewName);
    }
}
