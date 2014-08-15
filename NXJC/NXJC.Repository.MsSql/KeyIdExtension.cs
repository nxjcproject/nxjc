using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Configuration;

namespace NXJC.Repository
{
    /// <summary>
    /// 获取KeyId值的对象
    /// </summary>
    public class KeyIdExtension
    {
        private static readonly string connectionString = ApplicationSettingsFactory.GetApplicationSettings().ConnectionString;

        public static int GetKeyIdBy(SqlCommand command)
        {
            int result = 0;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_key_id";

            SqlParameter parameter = new SqlParameter("@key", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            int.TryParse(parameter.Value.ToString(), out result);
            command.Parameters.Clear();

            return result;
        }

        public static int GetKeyId()
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_key_id";

                SqlParameter parameter = new SqlParameter("@key", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);

                conn.Open();
                command.ExecuteNonQuery();
                int.TryParse(parameter.Value.ToString(), out result);
            }

            return result;
        }
    }
}
