﻿using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDataAdapter
{
    public class ComplexQuery
    {
        private IList<NeedField> _needFields;
        private JoinCriterion _joinCriterion;
        private IList<Criterion> _criterions;
        private SqlOperator _sqlOperator;

        public ComplexQuery()
        {
            _needFields = new List<NeedField>();
            _criterions = new List<Criterion>();
        }

        public ComplexQuery(IEnumerable<NeedField> needFields, JoinCriterion joinCriterion)
        {
            _joinCriterion = joinCriterion;
            _needFields = needFields.ToList();
            _criterions = new List<Criterion>();
        }

        public ComplexQuery(IEnumerable<NeedField> needFields)
        {
            _needFields = needFields.ToList();
            _criterions = new List<Criterion>();
        }

        public ComplexQuery(JoinCriterion joinCriterion, IEnumerable<NeedField> needFields, IEnumerable<Criterion> criterions)
        {
            _joinCriterion = joinCriterion;
            _needFields = needFields.ToList();
            _criterions = criterions.ToList();
        }

        public int TopNumber { get; set; }
        /// <summary>
        /// 必要时使用字段的全称（表名加字段名）
        /// </summary>
        public OrderByClause OrderByClause { get; set; }
        public bool IsDictinct { get; set; }

        public JoinCriterion JoinCriterion
        {
            get { return _joinCriterion; }
        }

        public IEnumerable<NeedField> NeedFields
        {
            get { return _needFields; }
            set { _needFields = value.ToList(); }
        }

        public IEnumerable<Criterion> Criterions
        {
            get { return _criterions; }
            set { _criterions = value.ToList(); }
        }

        public SqlOperator SqlOperator
        {
            get { return _sqlOperator; }
            set { _sqlOperator = value; }
        }

        /// <summary>
        /// 连接字段字典，键为表名，值为字段名
        /// </summary>
        /// <param name="joinFieldDictionary"></param>
        /// <param name="joinType"></param>
        public void AddJoinCriterion(IDictionary<string, string> joinFieldDictionary, JoinType joinType)
        {
            JoinCriterion join = new JoinCriterion();
            join.JoinFieldDictionary = joinFieldDictionary;
            join.JoinType = joinType;
            _joinCriterion = join;
        }
        public void AddJoinCriterion(string defaultJoinFieldName, JoinType joinType)
        {
            JoinCriterion join = new JoinCriterion
            {
                DefaultJoinFieldName = defaultJoinFieldName,
                JoinType = joinType
            };
            _joinCriterion = join;
        }
        public void AddJoinField(string tableName, string fieldName)
        {
            _joinCriterion.JoinFieldDictionary.Add(tableName, fieldName);
        }
        public void AddJoinType(JoinType type)
        {
            _joinCriterion.JoinType = type;
        }

        public void AddCriterion(string fieldName, string parameterName, object parameterValue, CriteriaOperator criteriaOperator)
        {
            _criterions.Add(new Criterion(fieldName, parameterName, parameterValue, criteriaOperator));
        }

        public void AddCriterion(string fieldName, object parameterValue, CriteriaOperator criteriaOperator)
        {
            _criterions.Add(new Criterion(fieldName, parameterValue, criteriaOperator));
        }

        public void AddCriterion(Criterion criterion)
        {
            _criterions.Add(criterion);
        }

        public void AddSqlOperator(SqlOperator sqlOperator)
        {
            _sqlOperator = sqlOperator;
        }

        public void AddNeedField(string tableName, string fieldName, string variableName)
        {
            _needFields.Add(new NeedField
            {
                TableName = tableName,
                FieldName = fieldName,
                VariableName = variableName
            });
        }

        public void AddNeedField(string tableName, string fieldName)
        {
            _needFields.Add(new NeedField
            {
                TableName = tableName,
                FieldName = fieldName
            });
        }
    }
}
