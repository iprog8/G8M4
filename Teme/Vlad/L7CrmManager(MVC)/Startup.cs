using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(L7CrmManager_MVC_.Startup))]
namespace L7CrmManager_MVC_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

