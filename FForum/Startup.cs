using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FForum.Startup))]
namespace FForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
