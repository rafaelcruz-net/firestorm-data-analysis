﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain
{
    public class Cidade
    {
        public int Id
        {
            get;
            set;
        }
        public string Nome
        {
            get;
            set;
        }

        public virtual Estado Estado
        {
            get;
            set;
        }
    }
}
