using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.GroupBy
{
    public class GroupByParser
    {
        public GroupByParser()
        {
            this.GroupBy = new List<GroupByAnalyser>(); 
        }

        public List<GroupByAnalyser> GroupBy 
        { 
            get; 
            set; 
        }

        public String ParseExpresion()
        {
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < this.GroupBy.Count; i++)
            {
                var expr = this.GroupBy[i];
                text.AppendFormat("{0}, ", expr.Property);
              
            }

            if (text.ToString().ToUpper().EndsWith(", "))
                text = text.Remove(text.Length - 2, 2);

            return text.ToString();
        }
    }
}
