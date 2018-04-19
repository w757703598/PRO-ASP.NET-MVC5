using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(第六章.Startup))]
namespace 第六章
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
