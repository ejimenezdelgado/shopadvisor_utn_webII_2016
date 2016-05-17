using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopAdvisor.Startup))]
namespace ShopAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
