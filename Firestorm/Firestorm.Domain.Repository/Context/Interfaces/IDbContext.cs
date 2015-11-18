using Firestorm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository.Context.Interfaces
{
    public interface IDbContext : IDisposable 
    {
        string ExecutionLog { get; set; }
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        DbEntityEntry Entry(object entity);
        void SetModified(object model, EntityState state);
        void Detach(object model);
        IDbSet<T> Set<T>() where T : class;
    }
}
