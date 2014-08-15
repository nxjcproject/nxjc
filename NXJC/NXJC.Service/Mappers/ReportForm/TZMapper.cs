using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Model.ReportForm;
using NXJC.Service.Views.ReportForm;
using SqlServerDataAdapter;
using NXJC.Repository.UserSystem;
using NXJC.Model.UserSystem.Repository;
using NXJC.Model.Repository;
using NXJC.Repository;
using NXJC.Model.ReportForm.Repository;
using NXJC.Repository.ReportForm;

namespace NXJC.Service.Mappers.ReportForm
{
    public static class TZMapper
    {
        public static TZView ConvertToView(this TZ item)
        {
            return new TZView
            {
                KeyID = item.KeyID,
                CreationDate = item.CreationDate,
                Date = item.Date,
                ModifiedFlag = item.ModifiedFlag,
                ModifierName = GetModifierName(item.ModifierID),
                ProductLineName = GetProductLineName(item.ProductLineID),
                Remarks = item.Remarks,
                Version = item.Version,
                ReportName = GetReportNameById(item.ReportID)
            };
        }

        public static IEnumerable<TZView> ConvertToViews(this IEnumerable<TZ> items)
        {
            IList<TZView> results = new List<TZView>();
            foreach (TZ item in items)
            {
                results.Add(item.ConvertToView());
            }
            return results;
        }

        public static TZ ConvertToTz(this TZView item)
        {
            return new TZ();
            //{
            //    KEY_ID = item.KEY_ID,
            //    ProductLineId = item.ProductLineId,
            //    NAME = item.NAME,
            //    Version = item.Version,
            //        //班别 = item.班别,
            //    报表类型 = item.报表类型,
            //    报表日期 = item.报表日期,
            //    备注 = item.备注,
            //    名称 = item.名称
            //};
        }

        public static IEnumerable<TZ> ConvertToTzs(this IEnumerable<TZView> items)
        {
            IList<TZ> results = new List<TZ>();
            foreach (var item in items)
            {
                results.Add(item.ConvertToTz());
            }
            return results;
        }

        public static string GetModifierName(string userId)
        {
            IUsersRepository repository = new UsersRepository();

            return repository.GetUserNameById(userId);
        }

        public static string GetProductLineName(int id)
        {
            IProductLineRepository repository = new ProductLineRepository();

            return repository.GetProductLineNameBy(id);
        }

        public static string GetReportNameById(int id)
        {
            IReportRepository repository = new ReportRepository();

            return repository.GetReportNameBy(id);
        }
    }
}
