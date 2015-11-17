using log4net;
using Firestorm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Firestorm.Infra.Data.Context
{
    public class FirestormBaseContext : DbContext, IUnitOfWork
    {
        ILog Logger = log4net.LogManager.GetLogger("Firestorm.Database.Context");
        
        public string ExecutionLog
        {
            get;
            set;
        }

             
        public FirestormBaseContext(DbConnection connection, bool contextOwnsConnection) : base(connection,contextOwnsConnection)
        {
            this.StartUpContext();
        }

        public FirestormBaseContext(string nameOrConnectionString) 
            :base(nameOrConnectionString)
        {
            this.StartUpContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            return this.Database.BeginTransaction();
        }


        private void StartUpContext()
        {
            var enableLog = false;

            if (ConfigurationManager.AppSettings["Firestorm.EntityFramework.Log.Enable"] != null)
            {
                bool enable;

                if (bool.TryParse(ConfigurationManager.AppSettings["Firestorm.EntityFramework.Log.Enable"].ToString(), out enable))
                    enableLog = enable;
            }

            if (enableLog)
            {
                this.Database.Log = (message =>
                {
                    Logger.Info(message);
                    this.ExecutionLog += message;
                });
            }
        }

    }
}
