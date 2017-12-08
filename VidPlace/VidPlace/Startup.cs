using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidPlace.Startup))]
namespace VidPlace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
