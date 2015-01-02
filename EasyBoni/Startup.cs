using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyBoni.Startup))]
namespace EasyBoni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
