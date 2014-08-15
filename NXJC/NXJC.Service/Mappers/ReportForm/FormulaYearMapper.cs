using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Model.ReportForm;
using NXJC.Service.Views.ReportForm;

namespace NXJC.Service.Mappers.ReportForm
{
    public static class FormulaYearMapper
    {
        public static FormulaYearView ConvertToView(this FormulaYear item)
        {
            return new FormulaYearView
            {
                key_id = item.key_id,
                number = item.number,
                层次码 = item.层次码,
                峰期电耗 = item.峰期电耗,
                工序名称 = item.工序名称,
                谷期电耗 = item.谷期电耗,
                合计电耗 = item.合计电耗,
                平期电耗 = item.平期电耗
            };
        }

        public static IList<FormulaYearView> ConvertToViews(this IEnumerable<FormulaYear> items)
        {
            IList<FormulaYearView> results = new List<FormulaYearView>();

            foreach (var item in items)
            {
                results.Add(item.ConvertToView());
            }

            return results;
        }

        public static FormulaYear ConvertToFormulaYear(this FormulaYearView item)
        {
            return new FormulaYear
            {
                key_id = item.key_id,
                number = item.number,
                层次码 = item.层次码,
                峰期电耗 = item.峰期电耗,
                工序名称 = item.工序名称,
                谷期电耗 = item.谷期电耗,
                合计电耗 = item.合计电耗,
                平期电耗 = item.平期电耗
            };
        }

        public static IEnumerable<FormulaYear> ConvertToFormulaYears(this IEnumerable<FormulaYearView> items)
        {
            IList<FormulaYear> results = new List<FormulaYear>();

            foreach (var item in items)
            {
                results.Add(item.ConvertToFormulaYear());
            }

            return results;
        }
    }
}
