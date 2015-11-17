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
    public interface IDbContext<T> : IDisposable where T : class
    {
        string ExecutionLog { get; set; }
        DbSet<T> DbSet { get; set; }
        int SaveChanges();
        DbEntityEntry<T> Entry(T entity);
        DbEntityEntry Entry(object entity);
        void SetModified(object model, EntityState state);
        void Detach(object model);

    }
}
