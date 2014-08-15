using System;

namespace NXJC.Model.EnergyEfficiency
{
    public static class FormulaFactory
    {
        public static Formula CreateFormulaFor(Procedure procedure, string body)
        {
            return new Formula(procedure, body, DateTime.Now);
        }
    }
}
