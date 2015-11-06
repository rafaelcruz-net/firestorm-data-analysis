using Firestorm.Infra.Data.GroupBy;
using Firestorm.Infra.Data.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public class ExpressionParser
    {
        public ExpressionParser()
        {
            this.Expressions = new List<ExpressionAnalyser>();
            this.Sorts = new List<OrderByAnalyser>();
            this.GroupBy = new List<GroupByAnalyser>();

        }

        public List<ExpressionAnalyser> Expressions
        {
            get;
            set;
        }

        public List<OrderByAnalyser> Sorts
        {
            get;
            set;
        }
        
        public List<GroupByAnalyser> GroupBy 
        { 
            get; 
            set; 
        }

        public String ParseExpresion()
        {
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < this.Expressions.Count; i++)
            {
                var expr = this.Expressions[i];

                if (i != 0)
                {
                    if (expr is AndConditional)
                        text.Append(" and ");
                    if (expr is OrConditional)
                        text.Append(" or ");
                }

                text.Append(this.ResolveExpression(expr));
            }

            if (text.ToString().ToUpper().EndsWith("AND"))
                text = text.Remove(text.Length - 3, 3);

            if (text.ToString().ToUpper().EndsWith("OR"))
                text = text.Remove(text.Length - 2, 2);

            return text.ToString();
        }

        public String ParseSort()
        {
            StringBuilder text = new StringBuilder();

            OrderByParser expression = new OrderByParser();
            expression.Expressions = this.Sorts;

            return expression.ParseExpresion();
        }

        public String ParseGroupBy()
        {
            StringBuilder text = new StringBuilder();

            GroupByParser expression = new GroupByParser();
            expression.GroupBy = this.GroupBy;

            return expression.ParseExpresion();
        }
        
        #region Private Methods
        
        private string ResolveExpression(ExpressionAnalyser expr)
        {
            string rightValue = "{0}";
            string leftValue = "";

            rightValue = expr.Expression.Item3.Value.Trim();
            leftValue = expr.Expression.Item1.Property.Trim();

            if (expr.Expression.Item2 == Conditional.EQUAL)
            {
                return String.Format("{0} = {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.DIFFERENT)
            {
                return String.Format("{0} != {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.GREATER)
            {
                return String.Format("{0} > {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.GREATER_OR_EQUAL)
            {
                return String.Format("{0} >= {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.LESS)
            {
                return String.Format("{0} < {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.LESS_OR_EQUAL)
            {
                return String.Format("{0} <= {1}", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.CONTAINS)
            {
                return String.Format("{0}.Contains({1})", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.STARTSWITH)
            {
                return String.Format("{0}.StartsWith({1})", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.ENDSWITH)
            {
                return String.Format("{0}.EndsWith({1})", leftValue, rightValue);
            }
            if (expr.Expression.Item2 == Conditional.IN)
            {
                return String.Format("{0} in ({1})", leftValue, rightValue);
            }

            return String.Empty;
        }
        #endregion

    }
}
