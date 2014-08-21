using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NXJC.UI.Web.Report.ReportTemplate
{
    public class ReportDataGroup<T,Tz>
    {
        private List<T> _inserted;
        private List<T> _updated;
        private List<T> _deleted;
        private List<Tz> _tz;
        public ReportDataGroup()
        {
            _inserted = new List<T>(0);
            _updated = new List<T>(0);
            _deleted = new List<T>(0);
        }
        public List<Tz> tzValue
        {
            get { return _tz; }
            set { _tz = value; }
        }
        public List<T> inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
            }
        }
        public List<T> updated
        {
            get
            {
                return _updated;
            }
            set
            {
                _updated = value;
            }
        }
        public List<T> deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }
    }
}