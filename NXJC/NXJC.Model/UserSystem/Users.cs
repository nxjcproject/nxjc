using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXJC.Model.UserSystem
{
    public class Users : EntityBase<string>, IAggregateRoot
    {
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATOR { get; set; }
        public string DEPARTMENT_ID { get; set; }
        public int DISPLAY_INDEX { get; set; }
        public string EMAIL { get; set; }
        public DateTime LOGIN_TIME { get; set; }
        public int MODFIY_FLAG { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string REMARK { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLES_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PASSWORD { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
