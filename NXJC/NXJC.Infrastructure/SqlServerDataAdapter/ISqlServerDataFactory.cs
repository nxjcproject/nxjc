using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDataAdapter
{
    public interface ISqlServerDataFactory
    {
        int Remove(Delete delete);

        int Save<T>(Insert<T> insert);
        int Save<T>(Update<T> update);

        DataTable Query(Query query);
        DataTable Query(ComplexQuery complexQuery);
    }
}
