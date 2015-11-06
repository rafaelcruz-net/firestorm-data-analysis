using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public class AndConditional : ExpressionAnalyser
    {
        public AndConditional(ExpressionLeftSide leftSide, Conditional conditional, ExpressionRightSide rightSide) : base(leftSide,conditional,rightSide)
        {

        }
    }
}
