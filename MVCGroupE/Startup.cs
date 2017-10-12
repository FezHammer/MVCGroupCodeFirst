using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCGroupE.Startup))]
namespace MVCGroupE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
