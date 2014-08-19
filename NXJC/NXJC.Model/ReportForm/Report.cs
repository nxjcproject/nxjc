using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.ReportForm
{
    public class Report : EntityBase<int>, IAggregateRoot
    {
        public int ID {get;set;}
        public string Name { get; set; }
        public ReportType Type { get; set; }
        public string Remarks { get; set; }

        public override int Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
