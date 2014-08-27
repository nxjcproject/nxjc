using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.ProcessDataFoundation.Repository
{
    public interface IContrastTableRepository
    {
        /// <summary>
        /// 获取画面名集合
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetViewNames(int productLineId);
        /// <summary>
        /// 获得视图变量路径信息
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        IEnumerable<DataPathInformation> GetDataPaths(int productLineId, string viewName);
        /// <summary>
        /// 获得视图中所有变量的Id值
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        ArrayList GetVariableId(int productLineId, string viewName);
    }
}
