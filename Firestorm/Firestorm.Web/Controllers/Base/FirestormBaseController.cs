using Firestorm.Domain.Service.Interfaces;
using Firestorm.Infra.MVC.ActionResult;
using Firestorm.Infra.MVC.Controllers;
using Firestorm.Web.Controllers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firestorm.Web.Controllers.Base
{
    public class BaseController<T> : FirestormBaseController<T> where T : class
    {
        private readonly IServiceBase<T> _service;

        public IServiceBase<T> ApplicationServiceBase
        {
            get { return _service; }
        }

        public BaseController(IServiceBase<T> _service)
        {
            this._service = _service;
        }


        #region Overrides
        protected ViewResult FirestormView(string title, Func<FirestormJsonResult> jsonData, string view)
        {
            return View(title, jsonData, view);
        }

        protected ViewResult FirestormView(string title)
        {
            return View(title, null, null);
        }

        protected ViewResult FirestormView(string title, Func<FirestormJsonResult> jsonData)
        {
            return View(title, jsonData, null);
        }

        protected ViewResult FirestormView(Func<FirestormJsonResult> jsonData, string view)
        {
            return View(null, jsonData, view);
        }

        protected ViewResult FirestormView()
        {
            return View(null, null, null);
        }

        private ViewResult View(string title, Func<FirestormJsonResult> jsonData, string view)
        {
            if (String.IsNullOrEmpty(view))
                view = "_Consulta";

            return new FirestormViewResult(title, view, jsonData);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var attrController = filterContext.Controller.GetType().GetCustomAttributes(typeof(DisableExecutionLogAttribute), false);

            if (!(attrController != null && attrController.Length > 0))
            {
                var attr = filterContext.ActionDescriptor.GetCustomAttributes(typeof(DisableExecutionLogAttribute), false);

                if (!(attr != null && attr.Length > 0))
                {
                    if (filterContext.Result.GetType().IsGenericType)
                        if (filterContext.Result.GetType().GetGenericTypeDefinition() == typeof(FirestormJsonResult<>))
                            filterContext.Result.GetType().GetProperty("ExecutionLog").SetValue(filterContext.Result, this._service.ExecutionLog);
                }
            }

            base.OnActionExecuted(filterContext);
        }

        #endregion


        public override FirestormJsonResult GetAll()
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult GetAll(int pageSize)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult Get(object key)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult Post(T data)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult Put(T data)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult Delete(object keys)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult FilterAndSort(Infra.Data.Query.ExpressionParser expression, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult Operation(Infra.Data.Query.ExpressionParser expression, string operationType, string field)
        {
            throw new NotImplementedException();
        }

        public override FirestormJsonResult GroupBy(Infra.Data.Query.ExpressionParser expression, int? pageSize)
        {
            throw new NotImplementedException();
        }
    }
}