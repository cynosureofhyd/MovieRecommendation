using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PixelPerfect.Startup))]
namespace PixelPerfect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
