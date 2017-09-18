using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetMvcFirstApp.Startup))]
namespace AspNetMvcFirstApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
