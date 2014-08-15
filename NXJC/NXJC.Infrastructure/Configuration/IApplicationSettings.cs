using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string ConnectionString { get; }
        string IndustryEnergy_SHConnectionString { get; }
    }
}
