using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Query
{
    public enum Conditional
    {
        EQUAL = 1,
        DIFFERENT = 2,
        LESS_OR_EQUAL = 3,
        GREATER_OR_EQUAL = 4,
        LESS = 5,
        GREATER = 6,
        CONTAINS = 7,
        STARTSWITH = 8,
        ENDSWITH = 9,
        IN = 10,

    }
}
