using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.ReportForm
{
    public class TZ : EntityBase<Guid>, IAggregateRoot
    {
        public int ProductLineID { get; set; }
        public int ReportID { get; set; }
        public string Date { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? Version { get; set; }
        public string ModifierID { get; set; }
        public bool ModifiedFlag { get; set; }
        public string Remarks { get; set; }
        public Guid KeyID { get; set; } 

        public override Guid Id
        {
            get
            {
                return this.KeyID;                          
            }
            set
            {
                this.KeyID = value;
            }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
