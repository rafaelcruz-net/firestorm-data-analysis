using Newtonsoft.Json;
using Firestorm.Infra.Data.Order;
using Firestorm.Infra.Data.Query;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Factory
{
    public static class ExpressionFactory
    {
        public static ExpressionAnalyser CreateExpression(Expression expression, String leftSide, Conditional condition, String rightSide)
        {
            if (expression == Expression.NOTHING)
                return new ExpressionAnalyser(new ExpressionLeftSide(leftSide), condition, new ExpressionRightSide(rightSide));
            else if (expression == Expression.AND)
                return new AndConditional(new ExpressionLeftSide(leftSide), condition, new ExpressionRightSide(rightSide));

            return new OrConditional(new ExpressionLeftSide(leftSide), condition, new ExpressionRightSide(rightSide));
        }


        public static ExpressionParser CreateMultiExpression(params ExpressionAnalyser[] expressions)
        {
            ExpressionParser exprParser = new ExpressionParser();
            exprParser.Expressions.AddRange(expressions);
            return exprParser;
        }

        public static OrderByAnalyser CreateSort(String property, SortEnum sort)
        {
            return new OrderByAnalyser(property, sort);
        }

        public static List<OrderByAnalyser> CreateMultiSort(params OrderByAnalyser[] sorts)
        {
            return sorts.ToList();
        }

        public static String ToJson(this ExpressionParser expression)
        {
            dynamic jsonResult = new ExpandoObject();
            jsonResult.Expression = new ExpandoObject();
            jsonResult.Sort = new ExpandoObject();

            if (expression.Expressions != null && expression.Expressions.Count > 0)
            {                
                jsonResult.Expression.Expressions = new List<dynamic>();
                
                foreach (var exp in expression.Expressions)
                {
                    if (exp.GetType() == typeof(AndConditional))
                    {
                        jsonResult.Expression.Expressions.Add(new
                        {
                            AndConditional = exp.ToString()
                        });
                    }
                    else if (exp.GetType() == typeof(OrConditional))
                    {
                        jsonResult.Expression.Expressions.Add(new
                        {
                            OrConditional = exp.ToString()
                        });
                    }
                    else if (exp.GetType() == typeof(ExpressionAnalyser))
                    {
                        jsonResult.Expression.Expressions.Add(new
                        {
                            Conditional = exp.ToString()
                        });
                    }
                }
            }

            if (expression.Sorts != null && expression.Sorts.Count > 0)
            {                
                jsonResult.Sort.Expressions = new List<dynamic>();

                foreach (var sort in expression.Sorts)
                {
                    if (sort.Sort == SortEnum.ASC)
                    {
                        jsonResult.Sort.Expressions.Add(new
                        {
                            PropertyName = sort.Property,
                            Direction = SortEnum.ASC.ToString().ToLower()
                        });
                    }

                    if (sort.Sort == SortEnum.DESC)
                    {
                        jsonResult.Sort.Expressions.Add(new
                        {
                            PropertyName = sort.Property,
                            Direction = SortEnum.DESC.ToString().ToLower()
                        });
                    }

                }
            }

            return JsonConvert.SerializeObject(jsonResult);        
        }
    }
}
