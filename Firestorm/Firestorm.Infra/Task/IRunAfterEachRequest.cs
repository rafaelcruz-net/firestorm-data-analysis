using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Task
{
    public interface IRunAfterEachRequest
    {
        void Execute();
    }
}
