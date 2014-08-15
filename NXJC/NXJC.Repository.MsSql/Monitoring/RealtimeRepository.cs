using NXJC.Model.Monitoring;
using NXJC.Model.Monitoring.Repository;
using System;
using System.Collections.Generic;
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
    }
}
