using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmissionSystem.Startup))]
namespace AdmissionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
