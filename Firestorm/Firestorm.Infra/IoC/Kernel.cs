using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.IoC
{
    public class Kernel
    {
        private static IKernel _instance;

        public static IKernel Instance
        {
            get
            {
                return _instance;
            }
        }


        public Kernel(IKernel kernel)
        {
            _instance = kernel;
        }


        public static void RegisterKernel(IKernel kernel)
        {
            Kernel._instance = kernel;
        }


        public static IEnumerable<T> ResolveAllService<T>()
        {
            return Instance.GetAll<T>();
        }

        public static IEnumerable<T> ResolveAllService<T>(params IParameter[] parameters)
        {
            return Instance.GetAll<T>(parameters);
        }

        public static T ResolveService<T>()
        {
            return (T)Instance.Get<T>();
        }

        public static T ResolveService<T>(params IParameter[] parameters)
        {
            return (T)Instance.Get<T>(parameters);
        }

        public static T ResolveService<T>(String namedComponent)
        {
            return (T)Instance.Get<T>(namedComponent);
        }

        public static object ResolveService(Type service, params IParameter[] parameters)
        {
            return Instance.Get(service, parameters);
        }

        public static void StopKernel()
        {

        }

        public static void StartKernel(IKernel kernel)
        {
            RegisterKernel(kernel);
        }

    }
}
