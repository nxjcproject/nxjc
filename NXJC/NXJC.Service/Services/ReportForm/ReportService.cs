using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Model.ReportForm;
using NXJC.Repository.ReportForm;
using NXJC.Service.Messages.ReportForm;
using NXJC.Service.Mappers.ReportForm;
using NXJC.Repository;
using NXJC.Service.Views.ReportForm;
using SqlServerDataAdapter;
using SqlServerDataAdapter.Infrastruction;
using NXJC.Model.ReportForm.Repository;

namespace NXJC.Service.Services.ReportForm
{
    public class ReportService : IReportService
    {
        ITZRepository tzRepository = new TZRepository();
        IReportRepository reportRepository = new ReportRepository();
        FormulaYearRepository formulaYearRepository = new FormulaYearRepository();

        /// <summary>
        /// 跟据截止时间获得TZ数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TZResponse GetTZ(TZRequest request)
        {
            Query query = new Query("TZ");
            if (request.ReportType == "1")
            {
                string startTime = request.StartTime.Split('-')[0];
                string endTime = request.EndTime.Split('-')[0];
                query.AddCriterion("ReportID", "ReportID",int.Parse(request.ReportName), CriteriaOperator.Equal);
                query.AddCriterion("Date", "startDate", startTime, CriteriaOperator.MoreThanOrEqual);
                query.AddCriterion("Date", "endDate", endTime, CriteriaOperator.LessThanOrEqual);
                query.AddCriterion("Date", "____", CriteriaOperator.Like);
                if (request.ModifiedFlag != "0")
                {
                    bool modifiedFlag = bool.Parse(request.ModifiedFlag);
                    query.AddCriterion("ModifiedFlag","modifiedflag", modifiedFlag, CriteriaOperator.Equal);
                }
            }
            else if (request.ReportType == "2")
            {
                string startTime = request.StartTime.Split('-')[0] + "-" + request.StartTime.Split('-')[1];
                string endTime = request.EndTime.Split('-')[0] + "-" + request.EndTime.Split('-')[1];
                query.AddCriterion("ReportID", "ReportID", int.Parse(request.ReportName), CriteriaOperator.Equal);
                query.AddCriterion("Date", "startDate", startTime, CriteriaOperator.MoreThanOrEqual);
                query.AddCriterion("Date", "endDate", endTime, CriteriaOperator.LessThanOrEqual);
                query.AddCriterion("Date", "____-__", CriteriaOperator.Like);
                if (request.ModifiedFlag != "0")
                {
                    bool modifiedFlag = bool.Parse(request.ModifiedFlag);
                    query.AddCriterion("ModifiedFlag", "modifiedflag", modifiedFlag, CriteriaOperator.Equal);
                }
            }
            else if (request.ReportType == "3")
            {
                string startTime = request.StartTime.Split('-')[0] + request.StartTime.Split('-')[1] + request.StartTime.Split('-')[2];
                string endTime = request.EndTime.Split('-')[0] + request.EndTime.Split('-')[1] + request.EndTime.Split('-')[2];
                query.AddCriterion("ReportID", "ReportID", int.Parse(request.ReportName), CriteriaOperator.Equal);
                query.AddCriterion("Date", "startDate", startTime, CriteriaOperator.MoreThanOrEqual);
                query.AddCriterion("Date", "endDate", endTime, CriteriaOperator.LessThanOrEqual);
                query.AddCriterion("Date", "____-__-__", CriteriaOperator.Like);
                if (request.ModifiedFlag != "0")
                {
                    bool modifiedFlag = bool.Parse(request.ModifiedFlag);
                    query.AddCriterion("ModifiedFlag","modifiedflag", modifiedFlag, CriteriaOperator.Equal);
                }
            }
            else
            {
                throw new Exception("没有匹配的报表类型");
            }
            IEnumerable<TZ> tz = tzRepository.FindBy(query);
            return new TZResponse
            {
                TZViews = tz.ConvertToViews(),
                Success = true
            };
        }

        public IEnumerable<ReportNameView> GetReportNameViews()
        {
            IList<ReportNameView> result = new List<ReportNameView>();
            Query query = new Query("Report");
            IEnumerable<Report> reports = reportRepository.FindBy(query);

            foreach (var item in reports)
            {
                result.Add(new ReportNameView
                {
                    ID = item.Id,
                    Name = item.Name
                });
            }
            return result;
        }
        /// <summary>
        /// 通过KeyID获得FormulaYear数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FormulaYearResponse GetFormulaYearByKeyID(FormulaYearRequest request)
        {
            FormulaYearResponse response = new FormulaYearResponse();

            //IEnumerable<FormulaYear> results = formulaYearRepository.GetBy(request.KeyID);

            //response.FormulaYearViews = results.ConvertToViews();

            return response;
        }

        public TZResponse GetTZInformationByKeyID(TZRequest request)
        {
            TZ tz = tzRepository.FindBy(request.KeyID);
            TZResponse response = new TZResponse
            {
                TZView = tz.ConvertToView()
            };
            return response;
        }

        public ReportResponse GetRepoersByType(ReportRequest request)
        {
            ReportResponse response = new ReportResponse();

            Query query = new Query("Report");
            query.AddCriterion("Type", request.ReportType, CriteriaOperator.Equal);
            IEnumerable<Report> reports = reportRepository.FindBy(query);
            response.Reports = reports;

            return response;
        }


        ///// <summary>
        ///// 根据key_id获得TZ数据
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public TZResponse GetTZByKeyId(TZRequest request)
        //{
        //    TZ value = tzRepository.FindBy(request.KeyId);

        //    TZResponse result = new TZResponse
        //    {
        //        TZView = value.ConvertToView(),

        //        Message = "",
        //        Success = true
        //    };
        //    return result;
        //}

        ///// <summary>
        ///// 获得报表名称的列表
        ///// </summary>
        ///// <returns></returns>
        //public IDictionary<int, string> GetTableNameList()
        //{
        //    IEnumerable<TZ> tzs = tzRepository.FindAll();
        //    IDictionary<int, string> tableNames = new Dictionary<int, string>();
        //    int index = 0;
        //    foreach (var item in tzs)
        //    {
        //        if (!tableNames.Values.Contains(item.名称))
        //        {
        //            tableNames.Add(index, item.名称);
        //            index++;
        //        }
        //    }

        //    return tableNames;
        //}

        ///// <summary>
        ///// 获得FormulaYear数据
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public FormulaYearResponse GetFormulaYears(FormulaYearRequest request)
        //{
        //    FormulaYearResponse result = new FormulaYearResponse();

        //    IList<FormulaYearView> items = new List<FormulaYearView>();

        //    TZ tzValue = tzRepository.FindBy(request.keyId);
        //    IEnumerable<FormulaYear> values = formulaYearRepository.GetBy(request.keyId);

        //    result.FormulaYearViews = values.ConvertToViews();
        //    result.TZView = tzValue.ConvertToView();

        //    return result;
        //}

        ///// <summary>
        ///// FormulaYear存储
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public FormulaYearSaveResponse FormulaYearSave(FormulaYearSaveRequest request)
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork(); //实例化事务对象

        //    FormulaYearSaveResponse response = new FormulaYearSaveResponse();

        //    int newKeyId = KeyIdExtension.GetKeyId();

        //    TZ tzValue = request.TZView.ConvertToTz();
        //    tzValue.KEY_ID = newKeyId;
        //    //tzRepository.Add(tzValue);
        //    unitOfWork.RegisterNew(tzValue, tzRepository);

        //    IEnumerable<FormulaYear> formulaYearValues = request.FormulaYears.ConvertToFormulaYears();
        //    foreach (var item in formulaYearValues)
        //    {
        //        item.key_id = newKeyId;
        //        //formulaYearRepository.Add(item);
        //        unitOfWork.RegisterNew(item, formulaYearRepository);
        //    }

        //    unitOfWork.Commit();

        //    return response;
        //}
    }
}
