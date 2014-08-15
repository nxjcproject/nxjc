using SqlServerDataAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId>
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
