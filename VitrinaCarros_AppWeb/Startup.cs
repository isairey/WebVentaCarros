using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VitrinaCarros_AppWeb.Startup))]
namespace VitrinaCarros_AppWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
