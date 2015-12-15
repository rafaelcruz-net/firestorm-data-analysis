using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Firestorm.Web.App_Start
{
    public class NinjectConfig : Ninject.Web.Common.Bootstrapper
    {
        public static void RegisterServices(IKernel kernel)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");

            foreach (string pathAssembly in Directory.GetFiles(path, "Firestorm.*.dll"))
            {
                var assembly = Assembly.LoadFrom(pathAssembly);

                assembly.GetTypes()
                        .Where(x => x.IsSubclassOf(typeof(NinjectModule))).ToList().ForEach(x =>
                        {
                            var t = (NinjectModule)Activator.CreateInstance(x, new object[] { true });
                            kernel.Load(t);
                        });
            }

        }

    }
}