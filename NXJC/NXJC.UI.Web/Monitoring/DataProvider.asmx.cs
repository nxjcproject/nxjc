using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using NXJC.Repository.Monitoring;
using NXJC.Service.Services.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NXJC.UI.Web.Monitoring
{
    /// <summary>
    /// DataProvider 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class DataProvider : System.Web.Services.WebService
    {
        //private static IRealtimeRepository realtimeRepository = new RealtimeRepository();

        [WebMethod]
        public SceneMonitor GetCurrentSceneMonitor(int productLineId, string sceneName)
        {
            IMonitoringService service = new MonitoringService();

            IEnumerable<DataItem> dataItems = service.GetRealtimeDataItems(productLineId, sceneName);
            SceneMonitor result = new SceneMonitor
            {
                Id = DateTime.Now,
                Name = sceneName,
                DataSet = dataItems
            };
            //return realtimeRepository.GetCurrent(sceneName);
            return result;

        }
    }
}
