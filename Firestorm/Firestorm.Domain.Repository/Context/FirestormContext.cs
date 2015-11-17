using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firestorm.Infra.Data.Context;
using Firestorm.Domain.Repository.Context.Interfaces;
using System.Data.Entity;
using System.Data.Common;
using System.Reflection;
using Firestorm.Infra.Data.Interfaces;
using System.Data.Entity.Infrastructure;


namespace Firestorm.Domain.Repository.Context
{
    public class FirestormContext<T> : FirestormBaseContext, IDbContext<T> where T : class
    {

        #region Properties
        public DbSet<T> DbSet
        {
            get;
            set;
        }

        public new string ExecutionLog
        {
            get
            {
                return base.ExecutionLog;
            }
            set
            {
                base.ExecutionLog = value;
            }
        }
        #endregion

        #region Constructor

        public FirestormContext()
            : base("SIARMNET.Connection")
        {
            Database.SetInitializer<FirestormContext<T>>(null);
        }

        public FirestormContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Database.SetInitializer<FirestormContext<T>>(new DropCreateDatabaseAlways<FirestormContext<T>>());
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Fazendo o mapeamento com o banco de dados
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();


            //Adicionando os outros relacionamentos
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }



            base.OnModelCreating(modelBuilder);
        }


        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbEntityEntry<T> Entry(T entity)
        {
            return base.Entry<T>(entity);
        }

        public new DbEntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public virtual void SetModified(object model, EntityState state)
        {
            ((IObjectContextAdapter)this)
                            .ObjectContext
                            .ObjectStateManager
                            .ChangeObjectState(model,
                            state);
        }

        public virtual void Detach(object model)
        {

            ((IObjectContextAdapter)this).ObjectContext.Detach(model);

        }

    }
}
