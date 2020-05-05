using Microsoft.Owin;
using Owin;
using WebParkingMVC.Models;

[assembly: OwinStartupAttribute(typeof(WebParkingMVC.Startup))]
namespace WebParkingMVC
{
    public partial class Startup
    {
        

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

           /* using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationDbInitializer.InitializeIdentityData(db);
            }*/
        }
    }
}
