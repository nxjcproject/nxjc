using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXJC.Service.Views.ReportForm
{
    [Serializable]
    public class FormulaYearView
    {
        public int key_id { get; set; }
        public int number { get; set; }
        public string 层次码 { get; set; }
        public string 工序名称 { get; set; }
        public int 峰期电耗 { get; set; }
        public int 谷期电耗 { get; set; }
        public int 平期电耗 { get; set; }
        public int 合计电耗 { get; set; }
    }
}
