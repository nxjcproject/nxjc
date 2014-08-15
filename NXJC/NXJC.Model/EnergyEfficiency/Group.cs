using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.EnergyEfficiency
{
    public class Group : Procedure, IAggregateRoot
    {
        public Group(ProductLine productionLine, DateTime createdDate, int order) : base(productionLine, createdDate, order) { }

        /// <summary>
        /// 获取分组下的项目集合
        /// </summary>
        public virtual IEnumerable<Item> Items { get; private set; }
    }
}
