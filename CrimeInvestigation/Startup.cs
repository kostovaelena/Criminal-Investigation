using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrimeInvestigation.Startup))]
namespace CrimeInvestigation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
