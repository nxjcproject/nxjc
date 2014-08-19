using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;
using SqlServerDataAdapter;

namespace NXJC.Model.ReportForm.Repository
{
    public interface IReportRepository : IRepository<Report, int>
    {
        string GetReportNameBy(int id);
        IEnumerable<Report> GetByComplexQuery(ComplexQuery complexQuery);
    }
}
