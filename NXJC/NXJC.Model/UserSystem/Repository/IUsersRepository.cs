using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;

namespace NXJC.Model.UserSystem.Repository
{
    public interface IUsersRepository : IRepository<Users, string>
    {
        string GetUserNameById(string id);
    }
}
