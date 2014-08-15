using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring
{
    public class DataItem : ValueObjectBase
    {
        public string ID { get; set; }
        public string Value { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.ID))
                AddBrokenRule(DataItemBusinessRules.IdRequired);
        }
    }
}
