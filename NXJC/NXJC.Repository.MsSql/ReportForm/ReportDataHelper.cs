using NXJC.Infrastructure.Configuration;
using NXJC.Model.ReportForm;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace NXJC.Repository.ReportForm
{
    public class ReportDataHelper
    {
        private string connString;
        private ISqlServerDataFactory dataFactory;

        public ReportDataHelper()
        {
            connString = ConnectionStringFactory.NXJCConnectionString;
            dataFactory = new SqlServerDataFactory(connString);
        }

        public DataTable GetFormulaYearTable(Guid keyId, string tableName)
        {
            Query query = new Query(tableName);
            query.AddCriterion("KeyID", keyId, CriteriaOperator.Equal);
            DataTable dt = dataFactory.Query(query);
            return dt;
        }

        public string ChangeFormulaYear(string tableName,IList<FormulaYear> deleteItems, IList<FormulaYear> updateItems, IList<FormulaYear> insertItems)
        {
            try
            {
                foreach (var item in deleteItems)
                {
                    Delete delete = new Delete(tableName);
                    delete.AddCriterions("KeyID","myKeyID", item.KeyID, CriteriaOperator.Equal);
                    delete.AddCriterions("ID","myID", item.ID, CriteriaOperator.Equal);
                    delete.AddSqlOperator(SqlOperator.AND);
                    dataFactory.Remove(delete);
                }
                foreach (var item in updateItems)
                {
                    Update<FormulaYear> update = new Update<FormulaYear>(tableName, item);
                    update.AddCriterion("KeyID", "myKeyID",item.KeyID, CriteriaOperator.Equal);
                    update.AddCriterion("ID", "myID",item.ID, CriteriaOperator.Equal);
                    update.AddSqlOperator(SqlOperator.AND);
                    update.AddExcludeField("Id");
                    dataFactory.Save<FormulaYear>(update);
                }
                foreach (var item in insertItems)
                {
                    Insert<FormulaYear> insert = new Insert<FormulaYear>(tableName, item);
                    insert.AddExcludeField("Id");
                    dataFactory.Save<FormulaYear>(insert);
                }
            }
            catch
            {
                return "0";
            }
            return "1";
        }

        public string SaveAnotherFormulaYear(string tableName,IList<FormulaYear> childrenValues, TZ tzValue)
        {
            Guid newKeyID = Guid.NewGuid();
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in childrenValues)
                {
                    item.KeyID = newKeyID;
                    Insert<FormulaYear> insert = new Insert<FormulaYear>(tableName, item);
                    insert.AddExcludeField("Id");
                    dataFactory.Save<FormulaYear>(insert);
                }
                tzValue.KeyID = newKeyID;
                Insert<TZ> insertTz = new Insert<TZ>("TZ", tzValue);
                insertTz.AddExcludeField("Id");
                dataFactory.Save<TZ>(insertTz);

                scope.Complete();
            }

            return "1";
        }

    }
}
