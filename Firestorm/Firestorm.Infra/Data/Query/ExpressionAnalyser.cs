using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public class ExpressionAnalyser
    {
        public ExpressionAnalyser(ExpressionLeftSide leftSide, Conditional conditional, ExpressionRightSide rightSide)
        {
            this.Expression = new Tuple<ExpressionLeftSide, Conditional, ExpressionRightSide>(leftSide, conditional, rightSide);
        }

        public Tuple<ExpressionLeftSide, Conditional, ExpressionRightSide> Expression
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (Expression.Item2 == Conditional.CONTAINS)
                return String.Format("{0} Contains \"{1}\"", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.DIFFERENT)
                return String.Format("{0}!={1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.ENDSWITH)
                return String.Format("{0} EndsWith \"{1}\"", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.EQUAL)
                return String.Format("{0}={1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.GREATER)
                return String.Format("{0}>{1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.GREATER_OR_EQUAL)
                return String.Format("{0}>={1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.LESS)
                return String.Format("{0}<{1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.LESS_OR_EQUAL)
                return String.Format("{0}<={1}", Expression.Item1.Property, Expression.Item3.Value);
            else if (Expression.Item2 == Conditional.STARTSWITH)
                return String.Format("{0} StartsWith \"{1}\"", Expression.Item1.Property, Expression.Item3.Value);

            return String.Empty;

        }
    }
}
