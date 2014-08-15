using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXJC.Infrastructure.Domain;
using NXJC.Model.ReportForm;
using NXJC.Infrastructure.UnitOfWork;
using System.Data.SqlClient;
using NXJC.Infrastructure.Configuration;
using AutoMapper;
using NXJC.Model.ReportForm.Repository;

namespace NXJC.Repository.ReportForm
{
    //public class FormulaYearRepository : IFormulaYearRepository, IUnitOfWorkRepository
    //{
        //private readonly string connectionString = ApplicationSettingsFactory.GetApplicationSettings().ConnectionString;

        ///**********************************************************/
        //public void PersistCreationOf(IAggregateRoot entity)
        //{
        //    this.Add((FormulaYear)entity);
        //}

        //public void PersistUpdateOf(IAggregateRoot entity)
        //{
        //    this.Save((FormulaYear)entity);
        //}

        //public void PersistDeletionOf(IAggregateRoot entity)
        //{
        //    this.Remove((FormulaYear)entity);
        //}
        ///***********************************************************/

        //public void Save(FormulaYear entity)
        //{
        //    UpdateObject<FormulaYear> updateObject = new UpdateObject<FormulaYear>("table_formula_year", entity);
        //    updateObject.AddCriterion("key_id", "KEY_ID", entity.key_id, CriteriaOperator.Equal);
        //    updateObject.AddExcludeProperty("key_id");

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        SaveTranslator.TranslateIntoUpdate<FormulaYear>(updateObject, cmd);

        //        conn.Open();

        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new Exception("更新数据库TZ表失败");
        //        }
        //    }
        //}

        //public void Add(FormulaYear entity)
        //{
        //    InsertObject<FormulaYear> insertObject = new InsertObject<FormulaYear>("table_formula_year", entity);

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        SaveTranslator.TranslateIntoInsert<FormulaYear>(insertObject, cmd);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public void Remove(FormulaYear entity)
        //{
        //    DeleteObject deleteObject = new DeleteObject("table_formula_year");
        //    deleteObject.AddCriterions("key_id", "keyId", entity.key_id, CriteriaOperator.Equal);

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        DeleteTranslator.TranslateIntoDelete(deleteObject, cmd);

        //        conn.Open();

        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new Exception("在数据库TZ表中删除记录失败");
        //        }
        //    }
        //}

        //public FormulaYear FindBy(int id)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// 根据Key_id获得数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public IEnumerable<FormulaYear> GetBy(int id)
        //{
        //    IList<FormulaYear> results = new List<FormulaYear>();

        //    SelectObject selectObject = new SelectObject("table_formula_year");
        //    selectObject.AddCriterion("key_id", "key_id", id, CriteriaOperator.Equal);

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        SelectTranslator.TranslateIntoSelect(selectObject, cmd);
        //        conn.Open();

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            FormulaYear item = Mapper.DynamicMap<FormulaYear>(reader);
        //            results.Add(item);
        //        }
        //    }

        //    return results;
        //}

        //public IEnumerable<FormulaYear> FindAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<FormulaYear> FindBy(AutoSQL.Querying.Query query)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<FormulaYear> FindBy(AutoSQL.Querying.Query query, int index, int count)
        //{
        //    throw new NotImplementedException();
        //}
    //}
}
