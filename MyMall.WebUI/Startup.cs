using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMall.WebUI.Startup))]
namespace MyMall.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
