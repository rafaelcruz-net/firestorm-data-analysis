using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IDbSet<T> Set<T>() where T : class;
        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        int SaveChanges();

    }
}
