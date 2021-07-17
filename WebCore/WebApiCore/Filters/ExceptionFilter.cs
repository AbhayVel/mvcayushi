using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ModelsCoreProject;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Filters
{
    public class QdnExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly Logger _logger;
        public QdnExceptionFilterAttribute()
        {
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }
        public override void OnException(ExceptionContext context)
        {

        }
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            string error = $" Controller {context.RouteData.Values["Controller"]} - Action: {context.RouteData.Values["Action"]} - Error: {context.Exception.Message} - stackTrac : {context.Exception.StackTrace}";
            _logger.Error(error);
            var errorMessage = new ErrorMessage(GetMessage(context.Exception));
            context.Result = new ObjectResult(errorMessage)
            {
                StatusCode = 500
            };
           // context.ExceptionHandled = true;

        }
        private string GetMessage(Exception ex)
        {
            if ("DivideByZeroException".Equals(ex.GetType().Name))
            {
                return "Please check value";
            }
            return ex.Message;
        }

    }
}
