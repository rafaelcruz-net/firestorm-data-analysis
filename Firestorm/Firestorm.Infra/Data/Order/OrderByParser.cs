using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Order
{
    public class OrderByParser
    {
        public OrderByParser()
        {
            this.Expressions = new List<OrderByAnalyser>(); 
        }

        public List<OrderByAnalyser> Expressions
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

                if (expr.Sort == SortEnum.ASC)
                {
                    text.AppendFormat("{0} asc, ", expr.Property);
                }
                else if (expr.Sort == SortEnum.DESC)
                {
                    text.AppendFormat("{0} desc, ", expr.Property);
                }
            }

            if (text.ToString().ToUpper().EndsWith(", "))
            {
                text = text.Remove(text.Length - 2, 2);
            }

            return text.ToString();
        }
    }
}
