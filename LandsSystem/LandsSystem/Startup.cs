using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandsSystem.Startup))]
namespace LandsSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
