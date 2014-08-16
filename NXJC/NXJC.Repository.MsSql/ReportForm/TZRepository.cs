using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AutoMapper;
using NXJC.Infrastructure.Configuration;
using NXJC.Model.ReportForm;
using NXJC.Infrastructure.UnitOfWork;
using NXJC.Infrastructure.Domain;
using NXJC.Model.ReportForm.Repository;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using System.Data;

namespace NXJC.Repository.ReportForm
{
    public class TZRepository : IUnitOfWorkRepository, ITZRepository
    {
        private readonly string connectionString;
        private ISqlServerDataFactory dataFactory;

        public TZRepository()
        {
            connectionString = ApplicationSettingsFactory.GetApplicationSettings().ConnectionString;
            dataFactory = new SqlServerDataFactory(connectionString);
        }

        /********************************UnitOfWork**************************************************/
        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((TZ)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((TZ)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((TZ)entity);
        }
        /********************************************************************************************/

        public void Save(TZ entity)
        {
            Update<TZ> update = new Update<TZ>("TZ", entity);
            update.AddCriterion("KeyID", entity.Id, CriteriaOperator.Equal);
            update.AddExcludeField("KeyID");

            dataFactory.Save<TZ>(update);
        }

        public void Add(TZ entity)
        {
            Insert<TZ> insert = new Insert<TZ>("TZ", entity);
            dataFactory.Save<TZ>(insert);
        }

        public void Remove(TZ entity)
        {
            Delete delete = new Delete("TZ");
            delete.AddCriterions("KeyID", entity.Id, CriteriaOperator.Equal);
            dataFactory.Remove(delete);
        }

        public TZ FindBy(int id)
        {
            Query query = new Query("TZ");
            query.AddCriterion("KeyID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(query);

            if (table.Rows.Count > 0)
            {
                TZ result = new TZ
                {
                    KeyID = (Guid)table.Rows[0]["KeyID"],
                    ProductLineID = int.Parse(table.Rows[0]["ProductLineID"].ToString().Trim()),
                    ReportID = int.Parse(table.Rows[0]["ReportID"].ToString().Trim()),
                    Date = table.Rows[0]["Date"].ToString().Trim(),
                    CreationDate = (DateTime)table.Rows[0]["CreationDate"],
                    ModifierID = table.Rows[0]["ModifierID"].ToString().Trim(),
                    Version = (DateTime)table.Rows[0]["Version"],
                    ModifiedFlag = (bool)table.Rows[0]["ModifiedFlag"],
                    Remarks = table.Rows[0]["Remarks"].ToString().Trim()
                };
                return result;
            }
            else
            {
                return new TZ();
            }

        }

        public IEnumerable<TZ> FindAll()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TZ> FindBy(Query query)
        {
            IList<TZ> result = new List<TZ>();
            DataTable table = dataFactory.Query(query);

            foreach (DataRow row in table.Rows)
            {
                TZ tz = new TZ();

                                    //tz.KeyID = (Guid)row["KeyID"];
                    tz.ProductLineID = int.Parse(row["ProductLineID"].ToString().Trim());
                    tz.ReportID = int.Parse(row["ReportID"].ToString().Trim());
                    tz.Date = row["Date"].ToString().Trim();
                    tz.CreationDate = (DateTime)row["CreationDate"];
                    tz.ModifierID = row["ModifierID"].ToString().Trim();
                    tz.Version = (DateTime)row["Version"];
                    tz.ModifiedFlag = (bool)row["ModifiedFlag"];
                    tz.Remarks = row["Remarks"].ToString().Trim();
                //result.Add(new TZ
                //{
                //    KeyID = (Guid)row["KeyID"],
                //    ProductLineID = int.Parse(row["ProductLineID"].ToString().Trim()),
                //    ReportID = int.Parse(row["ReportID"].ToString().Trim()),
                //    Date = row["Date"].ToString().Trim(),
                //    CreationDate = (DateTime)row["CreationDate"],
                //    ModifierID = row["ModifierID"].ToString().Trim(),
                //    Version = (DateTime)row["Version"],
                //    ModifiedFlag = (bool)row["ModifiedFlag"],
                //    Remarks = row["Remarks"].ToString().Trim()
                //});
                    result.Add(tz);
            }
            return result;
        }

        public IEnumerable<TZ> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
