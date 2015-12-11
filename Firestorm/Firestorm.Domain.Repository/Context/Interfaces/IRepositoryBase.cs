using Firestorm.Domain.Definition;
using Firestorm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository.Context.Interfaces
{
    public interface IRepositoryBase<T> : IRepository<T> where T : class
    {
        string ExecutionLog { get; }

    }
}

