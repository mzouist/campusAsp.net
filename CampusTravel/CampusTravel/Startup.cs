using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusTravel.Startup))]
namespace CampusTravel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
