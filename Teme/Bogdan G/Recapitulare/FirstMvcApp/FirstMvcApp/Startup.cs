using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstMvcApp.Startup))]
namespace FirstMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
