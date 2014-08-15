using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model
{
    public class ProductLine : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }

        protected override void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
