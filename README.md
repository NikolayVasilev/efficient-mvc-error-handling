# pragmatic-mvc-error-handling
Application-level error handling in a .Net MVC project without updating the Web.config or using HandleError attributes that will act as a last resort and will allow your application to gracefully recover from all unexpected exceptions and errors.

To be honest, there are too many different approaches to error handling in ASP.NET MVC - you can, for example, use the section of the Web.config file and fiddle with the mapping, override the base Controller's OnException method, use/extend the HandleError attribute. All ASP.NET MVC stack traces essentially originate from the controllers and the previously mentioned approaches do a good job of dealing with those nasty exceptions but no matter what you do one will eventually creep its way towards the user in the form of the default yellow screen of death. Here comes your safety net - the Application_Error method in the global.asax file. This is your last resort to any errors that have slipped through your try/catch blocks to the outermost section of your ASP.NET MVC code. Every MVC application should override the Application_Error method and here's how to do it!

##Advantages of implementing an override of the Application_Error method

    *it's what ASP.NET calls right before it displays its dreaded error screen and can be used as a safety net to gracefully handle all unexpected errors
    *it can be used in combination with the above-mentioned different approaches
    *very SEO friendly - returns the appropriate HTTP status code (different approaches might even return 200, which is wrong on many levels)
    *doesn't change or "aspxerrorpath" the URL
    *doesn't require the use of HandleError attributes or Web.config setup and is very easy to setup on a project level
