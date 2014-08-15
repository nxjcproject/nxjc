using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.EnergyEfficiency
{
    public class ProcedureBusinessRules
    {
        public static readonly BusinessRule NameRequired = new BusinessRule("Name", "名称是必须的。");
    }
}
