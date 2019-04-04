using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PicturesSecurity.Startup))]
namespace PicturesSecurity
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
