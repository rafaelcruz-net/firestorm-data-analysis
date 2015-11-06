using System;
using System.Web.Mvc;
using System.Linq;
using Firestorm.Infra.MVC.ActionResult;
using Firestorm.Infra.Data.Query;
using Firestorm.Infra.Data.Order;

namespace Firestorm.Infra.MVC.Controllers
{
    public abstract class FirestormBaseController<T> : Controller
    {

        [Obsolete("Não use o metodo padrão para retorna Json para o cliente. Use o Metodo JsonSucess ou JsonError.")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Não use o metodo padrão para retornar Json para o cliente. Use o Metodo JsonSucess ou JsonError.");
        }

        public abstract FirestormJsonResult GetAll();

        public abstract FirestormJsonResult GetAll(int pageSize);

        public abstract FirestormJsonResult Get(object key);

        public abstract FirestormJsonResult Post(T data);

        public abstract FirestormJsonResult Put(T data);

        public abstract FirestormJsonResult Delete(object keys);

        public abstract FirestormJsonResult FilterAndSort(ExpressionParser expression, int? pageSize);

        public abstract FirestormJsonResult Operation(ExpressionParser expression, string operationType, string field);
        
        public abstract FirestormJsonResult GroupBy(ExpressionParser expression, int? pageSize);


        #region Json Result Implementation
        protected FirestormJsonResult JsonValidationError()
        {
            var result = new FirestormJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected FirestormJsonResult JsonError(string errorMessage)
        {
            var result = new FirestormJsonResult();

            result.AddError(errorMessage);

            return result;
        }

        protected FirestormJsonResult JsonError(string errorMessage, JsonRequestBehavior behavior)
        {
            var result = new FirestormJsonResult { JsonRequestBehavior = behavior };

            result.AddError(errorMessage);

            return result;
        }

        protected FirestormJsonResult<T> JsonSuccess<T>(T data)
        {
            return new FirestormJsonResult<T> { Data = data };
        }

        protected FirestormJsonResult<T> JsonSuccess<T>(T data, JsonRequestBehavior behavior)
        {
            return new FirestormJsonResult<T> { Data = data, JsonRequestBehavior = behavior };
        }

        

        #endregion
    }

}
