using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Definition
{
    public class FieldType
    {
        public Guid FieldTypeId { get; set; }

        public String NamedType { get; set; }

        public Type Type
        {
            get
            {
                if (String.IsNullOrEmpty(NamedType))
                    return Type.GetType(NamedType);

                return null;
            }
        }
    }
}
