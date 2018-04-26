using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Custom_Error_Pages.Utils;

namespace Custom_Error_Pages.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = (int)HttpStatusCode.NotFound;

            return this.View(this.GetError());
        }

        public ActionResult CustomError()
        {
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            

            return this.View("InternalServer", this.GetError());
        }

        public ActionResult Forbidden()
        {
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return this.View("Forbidden", this.GetError());
        }
        
        
        public ActionResult SendErrorEmail()
        {
            var error = this.GetError();

            GMailer.GmailUsername = "alexander.georgiev@source-weave.com";
            GMailer.GmailPassword = Password.EmailPassword;

            var mailer = new GMailer
            {
                ToEmail = "alexander.b.georgiev@gmail.com",
                Subject = "Error Email",
                Body = error.StackTrace,
                IsHtml = true
            };
            mailer.Send();

            return this.RedirectToAction("Index", "Home");
        }

        private Exception GetError()
        {
            return this.Session["lastError"] as Exception;
        }
    }
}