using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Admin_side.Startup))]
namespace Admin_side
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
