using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.Monitoring
{
    public class DataItemBusinessRules
    {
        public static readonly BusinessRule IdRequired = new BusinessRule("ID", "用于呈现的ID字段是必须的。");
    }
}
