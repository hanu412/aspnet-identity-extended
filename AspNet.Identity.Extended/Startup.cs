using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNet.Identity.Extended.Startup))]
namespace AspNet.Identity.Extended
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
