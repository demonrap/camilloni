using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fc.Startup))]
namespace fc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {   
            ConfigureAuth(app);
        }
    }
}
