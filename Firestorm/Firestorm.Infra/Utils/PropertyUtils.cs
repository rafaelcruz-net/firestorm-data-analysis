using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Utils
{
    public static class PropertyUtils
    {
       
        public static object GetPropertyValue(this object instance, string path)
        {
            var pp = path.Split('.');
            Type t = instance.GetType();

            foreach (var prop in pp)
            {
                PropertyInfo propInfo = t.GetProperty(prop);
                if (propInfo != null)
                {
                    instance = propInfo.GetValue(instance, null);
                    t = propInfo.PropertyType;
                }
                else throw new ArgumentException("Properties path is not correct");
            }

            return instance;
        }
    }
}
