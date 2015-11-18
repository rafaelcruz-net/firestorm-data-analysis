using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Definition
{
    public class Relation
    {
        public Guid Id { get; set; }
        public virtual Table ForeignTable { get; set; }
        public virtual Table PrimaryTable { get; set; }
        public virtual Field PrimaryField { get; set; }
        public virtual Field ForeignField { get; set; }
    }
}
