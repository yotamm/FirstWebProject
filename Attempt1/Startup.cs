using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Attempt1.Startup))]
namespace Attempt1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
