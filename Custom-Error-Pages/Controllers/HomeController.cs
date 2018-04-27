using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;

namespace Custom_Error_Pages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new AuthenticationException();
            return View();
        }
    }
}