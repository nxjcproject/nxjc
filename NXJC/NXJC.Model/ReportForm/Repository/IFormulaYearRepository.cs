﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.ReportForm.Repository
{
    public interface IFormulaYearRepository : IRepository<FormulaYear,int>
    {
        IEnumerable<FormulaYear> GetBy(int id);
    }
}
