using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHub_Latest.Startup))]
namespace GigHub_Latest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
