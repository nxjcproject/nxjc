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
                TableName = item.TableName,
                CreationDate = item.CreationDate,
                Date = item.Date,
                ModifiedFlag = item.ModifiedFlag,
                ModifierName = GetModifierName(item.ModifierID),
                ModifierID = item.ModifierID,
                ProductLineName = GetProductLineName(item.ProductLineID),
                ProductLineID = item.ProductLineID,
                Remarks = item.Remarks,
                Version = item.Version,
                ReportName = GetReportNameById(item.ReportID),
                ReportID = item.ReportID
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
            TZ result = new TZ();
            result.KeyID = item.KeyID;
            result.TableName = item.TableName;
            result.ModifiedFlag = item.ModifiedFlag;
            result.Date = item.Date;
            result.Version = item.Version;
            result.CreationDate = item.CreationDate;
            result.ModifierID = item.ModifierID;
            result.ReportID = item.ReportID;
            result.ProductLineID = item.ProductLineID;
            result.Remarks = item.Remarks;
            return result;
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
