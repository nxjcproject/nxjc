using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Model.UserSystem.Repository;
using NXJC.Infrastructure.UnitOfWork;
using NXJC.Model.UserSystem;
using SqlServerDataAdapter;
using NXJC.Infrastructure.Configuration;
using SqlServerDataAdapter.Infrastruction;
using System.Data;

namespace NXJC.Repository.UserSystem
{
    public class UsersRepository : IUnitOfWorkRepository, IUsersRepository
    {
        private readonly string connectionString;
        private ISqlServerDataFactory dataFactory;

        public UsersRepository()
        {
            connectionString = ApplicationSettingsFactory.GetApplicationSettings().IndustryEnergy_SHConnectionString;
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

        /**************************************************************************/


        public void Save(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users FindBy(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameById(string id)
        {
            ComplexQuery cmquery = new ComplexQuery();
            cmquery.AddNeedField("users", "USER_NAME");
            cmquery.AddCriterion("USER_ID", id, CriteriaOperator.Equal);
            DataTable table = dataFactory.Query(cmquery);

            return table.Rows[0][0].ToString().Trim();
        }
    }
}
