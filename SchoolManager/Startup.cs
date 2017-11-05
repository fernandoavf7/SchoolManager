using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolManager.Startup))]
namespace SchoolManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
