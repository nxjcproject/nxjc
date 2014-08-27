using NXJC.Infrastructure.Domain;
using NXJC.Model.ProcessDataFoundation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring.Repository
{
    public interface IRealtimeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        SceneMonitor GetLatest(string sceneName);
        /// <summary>
        /// 获得实时数据的table表
        /// </summary>
        /// <param name="dataPathInfor"></param>
        /// <returns></returns>
        DataTable GetDataItemTable(int productLineId, IEnumerable<DataPathInformation> dataPathInfor);
    }
}
