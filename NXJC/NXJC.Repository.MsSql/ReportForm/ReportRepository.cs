using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.UnitOfWork;
using NXJC.Model.ReportForm.Repository;
using NXJC.Model.ReportForm;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using NXJC.Infrastructure.Configuration;
using System.Data;
using System.Reflection;
using AutoMapper;

namespace NXJC.Repository.ReportForm
{
    public class ReportRepository : IUnitOfWorkRepository, IReportRepository
    {
        private readonly string connectionString;
        private ISqlServerDataFactory dataFactory;

        public ReportRepository()
        {
            connectionString = ConnectionStringFactory.GetNXJCConnectionString();
            dataFactory = new SqlServerDataFactory(connectionString);
        }

        public void PersistCreationOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            this.Add((Report)entity);
        }

        public void PersistUpdateOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            this.Save((Report)entity);
        }

        public void PersistDeletionOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            this.Remove((Report)entity);
        }

        ///////////////////////////////////////////////////////////////////////////
      
        public void Save(Report entity)
        {
            Update<Report> update = new Update<Report>("Report", entity);
            update.AddCriterion("ID", entity.Id, CriteriaOperator.Equal);
            update.AddExcludeField("ID");

            dataFactory.Save<Report>(update);
        }

        public void Add(Report entity)
        {
            Insert<Report> insert = new Insert<Report>("Report", entity);
            dataFactory.Save<Report>(insert);
        }

        public void Remove(Report entity)
        {
            Delete delete = new Delete("Report");
            delete.AddCriterions("ID", entity.Id, CriteriaOperator.Equal);
            dataFactory.Remove(delete);
        }

        public Report FindBy(int id)
        {
            Query query = new Query("Report");
            query.AddCriterion("ID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(query);

            return new Report
            {
                Id = int.Parse(table.Rows[0]["ID"].ToString().Trim()),
                Name = table.Rows[0]["Name"].ToString().Trim(),
                Type = (NXJC.Model.ReportForm.ReportType)table.Rows[0]["Type"],
                Remarks = table.Rows[0]["Remarks"].ToString().Trim()
            };
        }

        public IEnumerable<Report> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> FindBy(Query query)
        {
            IList<Report> results = new List<Report>();

            //return dataFactory.Query<Report>(query);
            DataTable table = dataFactory.Query(query);
            foreach (DataRow row in table.Rows)
            {
                Report item = new Report();
                item.ID = int.Parse(row["ID"].ToString().Trim());
                item.Name = row["Name"].ToString().Trim();
                item.Type = (NXJC.Model.ReportForm.ReportType)(row["Type"]);
                item.Remarks = row["Remarks"].ToString().Trim();
                //results.Add(new Report
                //{
                //    Id = int.Parse(row["ID"].ToString().Trim()),
                //    Name = row["Name"].ToString().Trim(),
                //    Type = (NXJC.Model.ReportForm.ReportType)row["Type"],
                //    Remarks = row["Remarks"].ToString().Trim()
                //});
                results.Add(item);
            }
            return results;
        }

        public IEnumerable<Report> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public string GetReportNameBy(int id)
        {
            ComplexQuery cmquery = new ComplexQuery();
            cmquery.AddNeedField("Report", "Name");
            cmquery.AddCriterion("ID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(cmquery);

            return table.Rows[0][0].ToString().Trim();
        }


        public IEnumerable<Report> GetByComplexQuery(ComplexQuery complexQuery)
        {
            throw new NotImplementedException();
        }
    }
}
