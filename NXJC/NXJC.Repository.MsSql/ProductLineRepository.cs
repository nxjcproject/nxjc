using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.UnitOfWork;
using NXJC.Model.Repository;
using NXJC.Model;
using SqlServerDataAdapter;
using NXJC.Infrastructure.Configuration;
using SqlServerDataAdapter.Infrastruction;
using System.Data;

namespace NXJC.Repository
{
    public class ProductLineRepository : IUnitOfWorkRepository, IProductLineRepository
    {
        private readonly string connectionString;
        private ISqlServerDataFactory dataFactory;

        public ProductLineRepository()
        {
            connectionString = ConnectionStringFactory.NXJCConnectionString;
            dataFactory = new SqlServerDataFactory(connectionString);
        }

        public void PersistCreationOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        /////////////////////////////////////////////////////////////////////////////////



        public void Save(ProductLine entity)
        {
            Update<ProductLine> update = new Update<ProductLine>("ProductLine", entity);
            update.AddCriterion("ID", entity.Id, CriteriaOperator.Equal);
            update.AddExcludeField("ID");

            dataFactory.Save<ProductLine>(update);
        }

        public void Add(ProductLine entity)
        {
            Insert<ProductLine> insert = new Insert<ProductLine>("ProductLine", entity);
            dataFactory.Save<ProductLine>(insert);
        }

        public void Remove(ProductLine entity)
        {
            Delete delete = new Delete("ProductLine");
            delete.AddCriterions("ID", entity.Id, CriteriaOperator.Equal);
            dataFactory.Remove(delete);
        }

        public ProductLine FindBy(int id)
        {
            Query query = new Query("ProductLine");
            query.AddCriterion("ID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(query);

            ProductLine result = new ProductLine
            {
                Id = int.Parse(table.Rows[0]["ID"].ToString().Trim()),
                Address = table.Rows[0]["Address"].ToString().Trim(),
                Name = table.Rows[0]["Name"].ToString().Trim(),
                Remarks = table.Rows[0]["Remarks"].ToString().Trim(),
            };
            return result;
        }

        public IEnumerable<ProductLine> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductLine> FindBy(Query query)
        {
            IList<ProductLine> results = new List<ProductLine>();
            DataTable table = dataFactory.Query(query);
            foreach(DataRow row in table.Rows)
            {
                results.Add(new ProductLine{
                    Address = row["Address"].ToString().Trim(),
                    Id = int.Parse(row["ID"].ToString().Trim()),
                    Name = row["Name"].ToString().Trim(),
                    Remarks = row["Remarks"].ToString().Trim()
                });
            }
            return results;
        }

        public IEnumerable<ProductLine> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public string GetProductLineNameBy(int id)
        {
            ComplexQuery cmquery = new ComplexQuery();
            cmquery.AddNeedField("ProductLine", "Name");
            cmquery.AddCriterion("ID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(cmquery);

            return table.Rows[0][0].ToString().Trim();
        }
    }
}
