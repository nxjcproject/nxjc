using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.Repository
{
    public interface IProductLineRepository : IRepository<ProductLine, int>
    {
        string GetProductLineNameBy(int id);
    }
}
