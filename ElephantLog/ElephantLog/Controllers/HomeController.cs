using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ElephantLog.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello world";
        }
    }
}
