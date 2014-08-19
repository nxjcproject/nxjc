using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.ReportForm
{
    public class FormulaYear : EntityBase<Guid>, IAggregateRoot
    {
        public Guid KeyID { get; set; }
        public int number { get; set; }
        public int Energy { get; set; }

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
