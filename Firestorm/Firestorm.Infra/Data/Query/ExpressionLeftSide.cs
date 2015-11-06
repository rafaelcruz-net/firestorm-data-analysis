using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public class ExpressionLeftSide
    {

        public ExpressionLeftSide(String property)
        {
            this.Property = property;
        }

        public String Property
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
