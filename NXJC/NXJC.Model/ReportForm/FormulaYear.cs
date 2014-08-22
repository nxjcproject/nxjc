using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace NXJC.Model.ReportForm
{
    //[DataContract]
    public class FormulaYear : EntityBase<Guid>, IAggregateRoot
    {
        public Guid KeyID { get; set; }
        public int Number { get; set; }
        //public int Energy { get; set; }
        public string LevelCode { get; set; }
        public string ProcessName { get; set; }
        public int PeakPower { get; set; }
        public int HighPeakPower { get; set; }
        public int ValleyPower { get; set; }
        public int FlatPower { get; set; }
        public int TotalPower { get; set; }

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
