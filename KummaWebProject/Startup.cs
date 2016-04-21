using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KummaWebProject.Startup))]
namespace KummaWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
