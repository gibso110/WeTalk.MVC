using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeTalk.WebMVC.Startup))]
namespace WeTalk.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
