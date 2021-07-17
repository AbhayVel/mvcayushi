using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Filters;

namespace WebApiCore.Controllers
{
    [QdnExceptionFilterAttribute]
    [QdnActionFilter]
    public class BaseController : ControllerBase
    {
        
    }
}
