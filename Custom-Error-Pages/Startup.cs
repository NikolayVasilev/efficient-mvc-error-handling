using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Custom_Error_Pages.Startup))]
namespace Custom_Error_Pages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
