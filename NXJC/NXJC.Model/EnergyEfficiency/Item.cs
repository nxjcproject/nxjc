using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.EnergyEfficiency
{
    public class Item : Procedure, IAggregateRoot
    {
        public Item(ProductLine productionLine, DateTime createdDate, int order) : base(productionLine, createdDate, order) { }
        
        /// <summary>
        /// 获取所属分组
        /// </summary>
        public virtual Group Group { get; private set; }
    }
}
