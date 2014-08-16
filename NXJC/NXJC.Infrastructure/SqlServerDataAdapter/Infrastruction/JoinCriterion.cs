using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDataAdapter.Infrastruction
{
    public class JoinCriterion
    {
        public string JoinFieldName { get; set; }
        public JoinType JoinType { get; set; }
    }
}
