using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NXJC.UI.Web.Report.ReportTemplate
{
    [DataContract]
    public class ReportDataSaveAnother<T, Tz>
    {
        private List<T> _childrenValue;
        private List<Tz> _tzValue;

        public ReportDataSaveAnother()
        {
            _childrenValue = new List<T>();
            _tzValue = new List<Tz>();
        }
        [DataMember]
        public List<T> ChildrenValue
        {
            get { return _childrenValue; }
            set { _childrenValue = value; }
        }
        [DataMember]
        public List<Tz> TzValue
        {
            get { return _tzValue; }
            set { _tzValue = value; }
        }
    }
}