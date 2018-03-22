using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_Desarrollo_8_10.Startup))]
namespace WEB_Desarrollo_8_10
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
