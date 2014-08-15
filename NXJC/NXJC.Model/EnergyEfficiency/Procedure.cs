using NXJC.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NXJC.Model.EnergyEfficiency
{
    public abstract class Procedure : EntityBase<int>
    {
        private readonly ProductLine _productionLine;
        private IList<Formula> _formulas;
        private DateTime _createdDate;
        private int _order;

        public Procedure(ProductLine productionLine)
            : this(productionLine, DateTime.Now, -1)
        { }

        public Procedure(ProductLine productionLine, DateTime createdDate, int order)
        {
            _productionLine = productionLine;
            _formulas = new List<Formula>(); 
            _createdDate = createdDate;
            _order = order;
        }

        /// <summary>
        /// 获取生产线
        /// </summary>
        public ProductLine ProductionLine
        {
            get { return _productionLine; }
        }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置公式变量名
        /// </summary>
        public string VariableName { get; set; }
        /// <summary>
        /// 获取创建日期
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _createdDate; }
        }
        /// <summary>
        /// 获取排序位置
        /// </summary>
        public int Order
        {
            get { return _order; }
        }
        /// <summary>
        /// 获取公式集合
        /// </summary>
        public IEnumerable<Formula> Formulas
        {
            get { return _formulas; }
        }
        /// <summary>
        /// 获取当前公式
        /// </summary>
        public Formula CurrentFormula
        {
            get { return _formulas.OrderByDescending(f => f.CreatedDate).FirstOrDefault(); }
        }
        /// <summary>
        /// 添加新公式
        /// </summary>
        /// <param name="formula"></param>
        public void Add(string formula)
        {
            _formulas.Add(FormulaFactory.CreateFormulaFor(this, formula));
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name.Trim()))
                base.AddBrokenRule(ProcedureBusinessRules.NameRequired);

            foreach (Formula formula in Formulas)
                formula.ThrowExceptionIfInvalid();
        }
    }
}
