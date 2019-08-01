using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourHub.Startup))]
namespace TourHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
