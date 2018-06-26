using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCUSERROLE.Startup))]
namespace MVCUSERROLE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
