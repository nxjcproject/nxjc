using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring.Repository
{
    public interface IContrastTableRepository
    {
        IEnumerable<DataPathInformation> GetDataPaths(string viewName);
        ArrayList GetVariableId(string viewName);
    }
}
