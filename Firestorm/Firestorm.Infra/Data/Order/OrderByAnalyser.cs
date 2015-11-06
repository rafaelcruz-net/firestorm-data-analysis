using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Order
{
    public class OrderByAnalyser
    {
        public OrderByAnalyser(String property, SortEnum sort)
        {
            this.Property = property;
            this.Sort = sort;
        }

        public string Property 
        { 
            get; 
            set; 
        }

        public SortEnum Sort 
        { 
            get; 
            set; 
        }


    }
}
