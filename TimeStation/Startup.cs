using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeStation.Startup))]
namespace TimeStation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
