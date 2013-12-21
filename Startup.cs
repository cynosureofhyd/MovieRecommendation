using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRecommendation.Startup))]
namespace MovieRecommendation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
