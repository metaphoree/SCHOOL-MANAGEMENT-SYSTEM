using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rhino_Web.Startup))]
namespace Rhino_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
