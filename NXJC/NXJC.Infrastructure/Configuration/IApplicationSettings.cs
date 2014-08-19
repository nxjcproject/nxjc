using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string NXJCConnectionString { get; }
        string ProcessDataConnectionString { get; }
        string IndustryEnergy_SHConnectionString { get; }
        string Db_01_WastedHeatPowerConnectionString { get; }
    }
}
