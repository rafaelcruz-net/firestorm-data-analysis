using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.GroupBy
{
    public class GroupByAnalyser
    {
        public GroupByAnalyser(string property)
        {
            this.Property = property;
        }

        public string Property
        {
            get;
            set;
        }
    }
}
