using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aerolinea.Startup))]
namespace Aerolinea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
