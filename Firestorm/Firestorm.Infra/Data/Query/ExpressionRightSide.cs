using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public class ExpressionRightSide
    {

        public ExpressionRightSide(String value)
        {
            this.Value = value;
        }

        public String Value
        {
            get;
            set;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        
    }
}
