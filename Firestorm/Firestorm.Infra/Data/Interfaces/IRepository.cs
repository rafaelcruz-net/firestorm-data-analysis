using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Infra.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Save(T model);
        int Update(T model);
        void Delete(T model);
        List<T> GetAll();
        T GetById(object id);
        List<T> Where(Expression<Func<T, bool>> expression);

    }
}
