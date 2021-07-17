using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Filters
{
    public class QdnActionFilter : Attribute, IActionFilter
    {
        private readonly Logger _logger;

        DateTime StartDateTime;

        DateTime EndDateTime;

        int mintime = 100;

        public   QdnActionFilter()
        {
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            EndDateTime = DateTime.Now;
            var time = (EndDateTime - StartDateTime).TotalMilliseconds;
            context.HttpContext.Response.Headers.Add("TimeTaken", time.ToString());
            if (time< mintime)
            {
                return;
            }
            var str = time.ToString();
            string info = $" Controller {context.RouteData.Values["Controller"]} - Action: {context.RouteData.Values["Action"]} - Info {str}";
            _logger.Info(info);
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StartDateTime = DateTime.Now;
        }
    }
}
