using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSHCWebApp.Startup))]
namespace RSHCWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
