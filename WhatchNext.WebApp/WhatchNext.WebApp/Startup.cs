using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhatchNext.WebApp.Startup))]
namespace WhatchNext.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
