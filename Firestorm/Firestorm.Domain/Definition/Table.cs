using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Definition
{
    public class Table
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public DateTime CreationDate { get; set; }
        public string TableSchema { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

    }
}
