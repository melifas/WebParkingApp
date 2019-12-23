using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebParkingMVC.Startup))]
namespace WebParkingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
