# pragmatic-mvc-error-handling
Application-level error handling in a .Net MVC project without updating the Web.config or using HandleError attributes that will act as a last resort and will allow your application to gracefully recover from all unexpected exceptions and errors.

To be honest, there are too many different approaches to error handling in ASP.NET MVC - you can, for example, use the **<customErrors>** section of the **Web.config** file and fidle with the mapping, override the base Controller's **OnException** method, use/extend the **HandleError** attribute. All ASP.NET MVC stack traces essentially originate from the controllers and the previously mentioned approaches do a good job of dealing with those nasty exceptions but no matter what you do one will eventionally creep its way towards the user in the form of the default yellow screen of death. Here comes your safety net - the **Application_Error** method in the **global.asax** file. This is your last resort to any erros that have slipped through your try/catch blocks to the outermost section of your ASP.NET MVC code. Every MVC application should override the **Application_Error** method and here's how to do it!
  
## Advantages of implementing an Application_Error method

* it's what **ASP.NET** calls right before it displays its dreaded error screen and can be used as a safety net to gracefully handle all unexpected errors
* it can be used in combination with the above-mentioned different approaches
* very SEO friendly - returns the appropriate HTTP status code (different approaches might even return 200, which is wrong on many levels)
* doesn't change or "aspxerrorpath" the URL
* doesn't require the use of **HandleError** attributes or **Web.config** setup and is very easy to setup on a project level
  
## Before we begin

Delete your default **Error.cshtml** view from the **Shared** folder. You will not need it with this error handling implementation and it might mess with you if you haven't de-registered your **HandleError** attribute as a global action filter. As a matter of fact, just go ahead an delete it from the **RegisterGlobalFilters** in the **Global.asax** file

```csharp
public static void RegisterGlobalFilters(GlobalFilterCollection filters)
{
    //delete the below HandleError global filter registration
    filters.Add(new HandleErrorAttribute());
}
```
