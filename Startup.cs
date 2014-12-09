using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Itransition.Startup))]
namespace Itransition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
