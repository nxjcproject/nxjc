using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring.Repository
{
    public interface IContrastTableRepository
    {
        /// <summary>
        /// 获得视图变量路径信息
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        IEnumerable<DataPathInformation> GetDataPaths(string viewName);
        /// <summary>
        /// 获得视图中所有变量的Id值
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        ArrayList GetVariableId(string viewName);
    }
}
