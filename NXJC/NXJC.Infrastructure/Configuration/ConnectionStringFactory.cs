using SqlServerDataAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NXJC.Infrastructure.Configuration
{
    public static class ConnectionStringFactory
    {
        /// <summary>
        /// 以生产线ID为键的数据库字典
        /// </summary>
        private static readonly Dictionary<int, IList<DatabaseModel>> ProductLineToDatabase = new Dictionary<int,IList<DatabaseModel>>();
        /// <summary>
        /// 以DCS系统ID为键的数据库字典
        /// </summary>
        private static readonly Dictionary<int, IList<DatabaseModel>> DCSSystemToDatabase = new Dictionary<int, IList<DatabaseModel>>();
        /// <summary>
        /// 以分厂ID为键的数据库字典
        /// </summary>
        private static readonly Dictionary<int, IList<DatabaseModel>> FactoryToDatabase = new Dictionary<int, IList<DatabaseModel>>();
        /// <summary>
        /// 以分公司ID为键的数据库字典
        /// </summary>
        private static readonly Dictionary<int, IList<DatabaseModel>> CompanyToDatabase = new Dictionary<int, IList<DatabaseModel>>();
        /// <summary>
        /// 数据库访问类
        /// </summary>
        private static ISqlServerDataFactory dataFactory;
        /// <summary>
        /// 集团管理数据库连接字符串
        /// </summary>
        public static string NXJCConnectionString { get; set; }

        static ConnectionStringFactory()
        {
            NXJCConnectionString = ApplicationSettingsFactory.GetApplicationSettings().NXJCConnectionString;
            dataFactory = new SqlServerDataFactory(NXJCConnectionString);
            Initialize();
        }
        /// <summary>
        /// 初始化数据库字典
        /// </summary>
        public static void Initialize()
        {
            ProductLineToDatabase.Clear();
            Query query = new Query("DatabaseContrast");
            DataTable table = dataFactory.Query(query);

            foreach (DataRow row in table.Rows)
            {
                DatabaseModel model = new DatabaseModel
                {
                    DatabaseName = row["DatabaseName"].ToString().Trim(),
                    IPAddress = row["IPAddress"].ToString().Trim(),
                    UserID = row["UserID"].ToString().Trim(),
                    Password = row["Password"].ToString().Trim(),
                    Type = int.Parse(row["Type"].ToString())
                };

                //初始化以生产线ID为键的数据库字典
                {
                    int key = int.Parse(row["ProductLineID"].ToString());
                    if (!ProductLineToDatabase.Keys.Contains(key))                //判断键是不是已经存在于字典中，如果没有则添加该键值对
                    {
                        ProductLineToDatabase.Add(key, new List<DatabaseModel>());
                    }
               
                    if (!ProductLineToDatabase[key].Contains(model))
                    {
                        ProductLineToDatabase[key].Add(model);
                    }
                }
                //初始化以DCS系统ID为键的数据库字典
                {
                    int key = int.Parse(row["DCSSystemID"].ToString());
                    if (!DCSSystemToDatabase.Keys.Contains(key))
                    {
                        DCSSystemToDatabase.Add(key, new List<DatabaseModel>());
                    }

                    if (!DCSSystemToDatabase[key].Contains(model))
                    {
                        DCSSystemToDatabase[key].Add(model);
                    }
                }
                //初始化以分厂ID为键的数据库字典
                {
                    int key = int.Parse(row["FactoryID"].ToString());
                    if (!FactoryToDatabase.Keys.Contains(key))
                    {
                        FactoryToDatabase.Add(key, new List<DatabaseModel>());
                    }

                    if (!FactoryToDatabase[key].Contains(model))
                    {
                        FactoryToDatabase[key].Add(model);
                    }
                }
                //初始化以分公司ID为键的数据库字典
                {
                    int key = int.Parse(row["CompanyID"].ToString());
                    if (!CompanyToDatabase.Keys.Contains(key))
                    {
                        CompanyToDatabase.Add(key, new List<DatabaseModel>());
                    }

                    if (!CompanyToDatabase[key].Contains(model))
                    {
                        CompanyToDatabase[key].Add(model);
                    }
                }
            }
        }

        public static string GetNXJCConnectionString()
        {
            return ApplicationSettingsFactory.GetApplicationSettings().NXJCConnectionString;
        }
        /// <summary>
        /// 根据生产线ID获得连接字符串集合
        /// </summary>
        /// <param name="productLineID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ArrayList GetConnectionStringsByProductLineID(int productLineID, DatabaseType type)
        {
            ArrayList result = new ArrayList();
            foreach (var item in ProductLineToDatabase[productLineID])
            {
                if (item.Type == (int)type)
                {
                    result.Add(TranslateToConnectionString(item));
                }
            }
            return result;
        }
        /// <summary>
        /// 根据生产线ID获得连接字符串
        /// </summary>
        /// <param name="productLineID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetConnectionStringByProductLineID(int productLineID, DatabaseType type)
        {
            DatabaseModel model = ProductLineToDatabase[productLineID].FirstOrDefault();
            string result = TranslateToConnectionString(model);
            return result;
        }
        /// <summary>
        /// 根据DCS系统ID获得连接字符串
        /// </summary>
        /// <param name="dcsSystemID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetConnectionStringByDCSSystemID(int dcsSystemID, DatabaseType type)
        {
            DatabaseModel model = DCSSystemToDatabase[dcsSystemID].FirstOrDefault();
            string result = TranslateToConnectionString(model);
            return "";
        }
        /// <summary>
        /// 根据分厂ID获得连接字符串集合
        /// </summary>
        /// <param name="factoryID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ArrayList GetConnectionStringByFactoryID(int factoryID, DatabaseType type)
        {
            ArrayList result = new ArrayList();
            foreach (var item in FactoryToDatabase[factoryID])
            {
                if (item.Type == (int)type)
                {
                    result.Add(TranslateToConnectionString(item));
                }
            }
            return result;
        }
        /// <summary>
        /// 根据分公司ID获得连接字符串集合
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ArrayList GetConnectionStringByCompanyID(int companyID, DatabaseType type)
        {
            ArrayList result = new ArrayList();
            foreach (var item in CompanyToDatabase[companyID])
            {
                if (item.Type == (int)type)
                {
                    result.Add(TranslateToConnectionString(item));
                }
            }
            return result;
        }

        /// <summary>
        /// 将DatabaseModel翻译成连接字符串
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string TranslateToConnectionString(DatabaseModel model)
        {
            string connModel = ApplicationSettingsFactory.GetApplicationSettings().ConnectionStringModel;

            return String.Format(connModel, model.IPAddress, model.DatabaseName, model.UserID, model.Password);
        }
    }
}
