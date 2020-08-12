using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerMVC.Startup))]
namespace CustomerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
