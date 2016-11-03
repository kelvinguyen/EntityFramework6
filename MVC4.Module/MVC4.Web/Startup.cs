using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC4.Web.Startup))]
namespace MVC4.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
