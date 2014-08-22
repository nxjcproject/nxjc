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
                KeyID = item.KeyID,
                //number = item.number,
                //Energy = item.Energy
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
                KeyID = item.KeyID,
                //number = item.number,
                //Energy = item.Energy
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
