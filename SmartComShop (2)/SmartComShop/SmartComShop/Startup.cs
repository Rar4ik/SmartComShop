using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartComShop.Startup))]
namespace SmartComShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
