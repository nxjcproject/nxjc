using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring
{
    public class SceneMonitor : EntityBase<DateTime>, IAggregateRoot
    {
        public string Name { get; set; }
        public IEnumerable<DataItem> DataSet { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
