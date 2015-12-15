using Firestorm.Domain.Repository.Context.Interfaces;
using Firestorm.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Service.Base
{
    public class ServiceBase<T>: IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public string ExecutionLog
        {
            get { return this._repository.ExecutionLog; }
        }

        public int Save(T model)
        {
            return _repository.Save(model);
        }

        public int Update(T model)
        {
            return _repository.Update(model);
        }

        public void Delete(T model)
        {
            _repository.Delete(model);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public IEnumerable<T> OrderBy(Expression<System.Func<T, bool>> expression)
        {
            return _repository.OrderBy(expression);
        }

        public IEnumerable<T> GetAll(int? pageSize)
        {
            return _repository.GetAll(pageSize);
        }

    }
}
