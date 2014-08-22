using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;
using NXJC.Model.ReportForm;
using NXJC.Infrastructure.UnitOfWork;
using System.Data.SqlClient;
using NXJC.Infrastructure.Configuration;
using AutoMapper;
using NXJC.Model.ReportForm.Repository;
using SqlServerDataAdapter;
using System.Data;

namespace NXJC.Repository.ReportForm
{
    public class FormulaYearRepository : IFormulaYearRepository, IUnitOfWorkRepository
    {
        private readonly string connectionString;
        private ISqlServerDataFactory dataFactory;

        public FormulaYearRepository()
        {
            connectionString = ConnectionStringFactory.GetNXJCConnectionString();
            dataFactory = new SqlServerDataFactory(connectionString);
        }

        /**********************************************************/
        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((FormulaYear)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((FormulaYear)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((FormulaYear)entity);
        }
        /***********************************************************/

        public void Save(FormulaYear entity)
        {
        }

        public void Add(FormulaYear entity)
        {
        }

        public void Remove(FormulaYear entity)
        {
        }

        public FormulaYear FindBy(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Key_id获得数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public IEnumerable<FormulaYear> GetBy(Guid id)
        //{
        //    IList<FormulaYear> result = new List<FormulaYear>();
        //    Query query = new Query("FormulaYear");
        //    query.AddCriterion("KeyID", id, SqlServerDataAdapter.Infrastruction.CriteriaOperator.Equal);
        //    DataTable dt = dataFactory.Query(query);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        FormulaYear item = new FormulaYear();
        //        item.Energy = int.Parse(row["Energy"].ToString().Trim());
        //        item.KeyID = (Guid)row["KeyID"];
        //        item.number = int.Parse(row["number"].ToString().Trim());
        //        result.Add(item);
        //    }
        //    return result;
        //}

        public IEnumerable<FormulaYear> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormulaYear> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormulaYear> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormulaYear> GetBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
