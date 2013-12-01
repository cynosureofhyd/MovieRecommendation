using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FastClickJobs.Startup))]
namespace FastClickJobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
