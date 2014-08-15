using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.ReportForm
{
    public class FormulaYear : EntityBase<int>, IAggregateRoot
    {
        public int key_id { get; set; }
        public int number { get; set; }
        public string 层次码 { get; set; }
        public string 工序名称 { get; set; }
        public int 峰期电耗 { get; set; }
        public int 谷期电耗 { get; set; }
        public int 平期电耗 { get; set; }
        public int 合计电耗 { get; set; }

        public override int Id
        {
            get
            {
                return this.key_id;
            }
            set
            {
                this.key_id = value;
            }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
