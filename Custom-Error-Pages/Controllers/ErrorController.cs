using System;
using System.Net;
using System.Web.Mvc;
using Custom_Error_Pages.Utils;

namespace Custom_Error_Pages.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult CustomError()
        {
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            return this.View("InternalServer", this.GetError());
        }

        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = (int)HttpStatusCode.NotFound;

            return this.View(this.GetError());
        }

        public ActionResult Forbidden()
        {
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return this.View(this.GetError());
        }
        
        
        public ActionResult SendErrorEmail()
        {
            var error = this.GetError();

            GMailer.GmailUsername = "john@doe.com";
            GMailer.GmailPassword = Password.EmailPassword;

            var mailer = new GMailer
            {
                ToEmail = "john@doe.com",
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