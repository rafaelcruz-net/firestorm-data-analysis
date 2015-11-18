using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Definition
{
    public class Field
    {
        public Guid TableId { get; set; }
        public Guid FieldId { get; set; }
        public virtual FieldType Type { get; set; }
        public string FieldName { get; set; }
        public byte FieldPosition { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool IsUnique { get; set; }
        public bool PrimaryKey { get; set; }
        public bool IsIdentity { get; set; }
        public string DisplayFormat { get; set; }
        public bool Multiline { get; set; }
        public byte Visibility { get; set; }
        public bool? HasAutoComplete { get; set; }
        public virtual Table AutoCompleteTableReference { get; set; }
        public string AutoCompleteFieldReference { get; set; }
        
    }
}
