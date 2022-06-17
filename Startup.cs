using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineApplication.Startup))]
namespace AirlineApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
