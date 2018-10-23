using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sem3Project.Startup))]
namespace Sem3Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
