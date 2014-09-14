using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public static class ConnectionStringFactory
    {
        public static readonly Dictionary<int, IList<DatabaseModel>> ProductLineToDatabase = new Dictionary<int,IList<DatabaseModel>>();

        public static readonly Dictionary<int, IList<DatabaseModel>> DCSSystemToDatabase = new Dictionary<int,IList<DatabaseModel>>();

        public static readonly Dictionary<int, IList<DatabaseModel>> FactoryToDatabase = new Dictionary<int,IList<DatabaseModel>>();

        public static readonly Dictionary<int, IList<DatabaseModel>> CompanyToDatabase = new Dictionary<int, IList<DatabaseModel>>();

        static ConnectionStringFactory()
        {

        }

        public static void InitializeProductLineToDatabase()
        {

        }
    }
}
