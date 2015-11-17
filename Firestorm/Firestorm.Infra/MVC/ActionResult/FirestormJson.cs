using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace Firestorm.Infra.MVC.ActionResult
{
    public class FirestormJsonResult : JsonResult
    {
        const string RequestRefused = "This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.";

        public IList<string> ErrorMessages { get; private set; }
        public HttpStatusCode Status { get; set; }


        public FirestormJsonResult() 
        {
            ErrorMessages = new List<string>();
        }

        public void AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        protected string ExecutionLog
        {
            get;
            set;
        } 

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(RequestRefused);

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            SerializeData(response);

        }

        protected virtual void SerializeData(HttpResponseBase response)
        {
            var originalData = Data;

            if (ErrorMessages.Any())
            {
                Data = new
                {
                    Success = false,
                    Content = originalData,
                    ErrorMessages = ErrorMessages.ToArray(),
                    RequestTime = DateTime.Now,
                    ExecutionLog = this.ExecutionLog
                };

                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                if (originalData != null)
                {

                    if (originalData.GetType().GetProperty("ExecutionLog") != null)
                    {
                        this.ExecutionLog = originalData.GetType().GetProperty("ExecutionLog").GetValue(originalData).ToString();

                        if (originalData.GetType().GetProperty("Rows") != null)
                            originalData = new { Rows = originalData.GetType().GetProperty("Rows").GetValue(originalData) };
                    }
                }

                Data = new
                {
                    Success = true,
                    Content = originalData,
                    ErrorMessages = String.Empty,
                    RequestTime = DateTime.Now,
                    ExecutionLog = this.ExecutionLog
                };

                response.StatusCode = (int)HttpStatusCode.OK;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new Firestorm.Infra.Utils.CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };

            response.Write(JsonConvert.SerializeObject(Data, settings));
        }
    }

    public class FirestormJsonResult<T> : FirestormJsonResult
    {
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }

        public new string ExecutionLog
        {
            get { return base.ExecutionLog; }
            set { base.ExecutionLog = value; }
        }

    }
}
