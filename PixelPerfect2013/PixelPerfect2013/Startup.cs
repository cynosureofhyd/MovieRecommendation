using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PixelPerfect2013.Startup))]
namespace PixelPerfect2013
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
