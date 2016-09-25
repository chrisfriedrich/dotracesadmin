using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotRacesAdministration.Startup))]
namespace DotRacesAdministration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
