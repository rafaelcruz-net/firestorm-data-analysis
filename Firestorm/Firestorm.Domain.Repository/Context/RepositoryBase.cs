using Firestorm.Domain.Repository.Context.Interfaces;
using Firestorm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Firestorm.Domain.Definition;
using System.Data;
using System.Data.Common;
using System.Collections;
using Ninject;
using System.Linq.Expressions;
using System.Configuration;

namespace Firestorm.Domain.Repository.Context
{
    public abstract class RepositoryBase<T> where T : class
    {

        [Inject]
        public IDbContext DbContext
        {
            get;
            private set;
        }

        public DbSet<T> DbSet
        {
            get;
            private set;
        }

           
        public RepositoryBase()
        {
            if (ConfigurationManager.AppSettings["DEFAULT_MAX_ROWS"] == null)
                throw new Exception("DEFAULT MAX ROW NOT FOUND");

            this.MaxRows = Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_MAX_ROWS"]);
        }

        public RepositoryBase(IDbContext context)
        {
            this.DbContext = context;
            this.DbSet = this.DbContext.Set<T>() as DbSet<T>;
        }

        public String TableName 
        { 
            get; 
            set; 
        }

        public Int32 MaxRows
        {
            get;
            set;
        }

        public string ExecutionLog
        {
            get { return this.DbContext.ExecutionLog;  }
            private set { this.DbContext.ExecutionLog = value; }
        }


        public virtual int Save(T model)
        {
            this.DbSet.Add(model);
            return this.SaveChanges();
        }

        public virtual int Update(T model)
        {
            var entry = this.DbContext.Entry(model);

            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.SetModified(model, EntityState.Modified);
            return this.SaveChanges();
        }

        public virtual void Delete(T model)
        {
            var entry = this.DbContext.Entry(model);

            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.SetModified(model, EntityState.Deleted);
            this.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            if (this.MaxRows > 0)
                return this.DbSet.Take(MaxRows).ToList();

            return this.DbSet.ToList();

        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual int SaveChanges()
        {
            return this.DbContext.SaveChanges();
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            if (this.MaxRows > 0)
                return this.DbSet.Where(expression).Take(this.MaxRows);

            return this.DbSet.Where(expression);

        }

        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression)
        {
            if (this.MaxRows > 0)
                return this.DbSet.OrderBy(expression).Take(this.MaxRows);

            return this.DbSet.OrderBy(expression);
        }

        public IEnumerable<T> GetAll(int? pageSize)
        {
            if (pageSize.HasValue)
            {
                return (from x in this.DbSet
                        select x).Take(pageSize.Value).ToList();
            }

            return this.GetAll();
        }



        #region Private Methods
        private void SetModified(T model, EntityState state)
        {
            DbContext.SetModified(model, state);
        }

        private void Detach(T model)
        {
            DbContext.Detach(model);
        }
        #endregion

    }
}
