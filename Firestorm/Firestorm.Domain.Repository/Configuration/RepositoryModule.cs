using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.Conventions;
using Ninject.Web;
using Ninject.Web.Mvc;
using Ninject.Web.Common;
using Ninject.Modules;
using Firestorm.Domain.Repository.Context.Interfaces;
using System.Data.Entity;
using Firestorm.Domain.Repository.Context;
using Firestorm.Infra.Data.Interfaces;


namespace Firestorm.Domain.Repository.Configuration
{
    public class RepositoryModule : NinjectModule
    {
        bool isInHttpContext = false;

        public RepositoryModule(bool _isInHttpContext)
        {
            this.isInHttpContext = _isInHttpContext;
        }

        public override void Load()
        {
            Bind<DbContext>().ToSelf().InThreadScope();
            Bind(typeof(IDbContext<>)).To(typeof(FirestormContext<>)).InThreadScope();
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>)).InRequestScope();


            this.Bind(x => x.FromThisAssembly()
                            .SelectAllClasses()
                            .Excluding<DbContext>()
                            .Excluding(typeof(FirestormContext<>))
                            .Excluding(typeof(RepositoryBase<>))
                            .Excluding<IMapping>()
                            .BindDefaultInterface()
                            .Configure((Ninject.Syntax.IBindingWhenInNamedWithOrOnSyntax<object> c) =>
                            {
                                if (isInHttpContext)
                                    c.InRequestScope();
                                else
                                    c.InTransientScope();
                            })
            );



        }
    }
}
