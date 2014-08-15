using NXJC.Infrastructure.Domain;
using System;

namespace NXJC.Model.EnergyEfficiency
{
    public class Formula : ValueObjectBase
    {
        private readonly Procedure _procedure;
        private readonly string _body;
        private readonly DateTime _createdDate;

        public Formula(Procedure procedure, string body, DateTime createdDate)
        {
            _procedure = procedure;
            _body = body;
            _createdDate = createdDate;
        }

        /// <summary>
        /// 获取所属工序
        /// </summary>
        public Procedure Procedure
        {
            get { return _procedure; }
        }
        /// <summary>
        /// 获取公式内容
        /// </summary>
        public string Body
        {
            get { return _body; }
        }
        /// <summary>
        /// 获取创建时间
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _createdDate; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}