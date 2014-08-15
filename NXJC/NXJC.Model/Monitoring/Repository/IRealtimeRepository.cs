using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring.Repository
{
    public interface IRealtimeRepository
    {
        SceneMonitor GetLatest(string sceneName);
    }
}
