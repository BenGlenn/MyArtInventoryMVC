using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyArtInventoryMVC.Startup))]
namespace MyArtInventoryMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
