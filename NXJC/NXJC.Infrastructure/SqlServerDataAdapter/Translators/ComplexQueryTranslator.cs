﻿using SqlServerDataAdapter.Infrastruction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDataAdapter.Translators
{
    public static class ComplexQueryTranslator
    {
        public static void TranslateIntoComplexQuery(ComplexQuery complexQuery, SqlCommand command)
        {
            string baseString = "SELECT ";
            StringBuilder result = new StringBuilder();
            result.Append(baseString);

            if (complexQuery.IsDictinct == true)
            {
                result.Append("DISTINCT ");
            }

            if (complexQuery.TopNumber != TopNumber.numberNull)
            {
                result.Append(TranslateHelper.GetTopNumber(complexQuery.TopNumber));
            }

            foreach (var item in complexQuery.NeedFields)
            {
                result.Append(TranslateHelper.GetFieldString(item));
            }
            result.Remove(result.Length - 1, 1);

            result.Append(" FROM ");
            result.Append(TranslateHelper.GetJoinConditionString(complexQuery.NeedFields, complexQuery.JoinCriterion));

            TranslateHelper.GetCriterionString(result, complexQuery.Criterions, command, complexQuery.SqlOperator);

            if (complexQuery.OrderByClause != null)
            {
                result.Append(TranslateHelper.GetStringFromOrderByClause(complexQuery.OrderByClause));
            }

            command.CommandText = result.ToString();

        }
    }
}
