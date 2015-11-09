using System;
using System.IO;
using System.Web.Mvc;

namespace Firestorm.Infra.MVC.ActionResult
{
    public class FirestormViewResult : ViewResult
    {

        public const string TITLE = "__Title";
        public const string CONTROLLER = "__Controller";
        public const string ACTION = "__Action";
        public const string JSON_DATA = "__JSON_Action";


        public string Title { get; set; }
        public string View { get; set; }
        public Func<FirestormJsonResult> JsonAction { get; set; }

        public FirestormViewResult(string title, string view)
        {
            this.Title = title;
            this.View = view;
        }

      
        public FirestormViewResult(string title, string view, Func<FirestormJsonResult> jsonAction)
        {
            this.Title = title;
            this.View = view;
            this.JsonAction = jsonAction;
        }


        public override void ExecuteResult(ControllerContext context)
        {

            if (!String.IsNullOrEmpty(this.Title))
                TempData[TITLE] = this.Title;
            else
                TempData[TITLE] = "Consulta";

            TempData[CONTROLLER] = context.Controller.ControllerContext.RouteData.Values["controller"];

            TempData[ACTION] = context.Controller.ControllerContext.RouteData.Values["action"];

            if (JsonAction != null)
            {
                TempData[JSON_DATA] = this.JsonAction.Method.Name;
            }

            ViewBag.Title = TempData[TITLE];


            base.ExecuteResult(context);
        }

        protected override ViewEngineResult FindView(ControllerContext context)
        {
            ViewEngineResult viewEngineResult = ViewEngines.Engines.FindView(context, this.View, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            return viewEngineResult;
            
        }
    }
}
