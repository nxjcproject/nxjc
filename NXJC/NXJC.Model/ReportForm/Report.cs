using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.ReportForm
{
    public class Report : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public ReportType Type { get; set; }
        public string Remarks { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
