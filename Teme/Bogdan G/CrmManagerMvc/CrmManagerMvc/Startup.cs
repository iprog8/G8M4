using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrmManagerMvc.Startup))]
namespace CrmManagerMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
