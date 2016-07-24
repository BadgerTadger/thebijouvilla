using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(thebijouvilla.Startup))]
namespace thebijouvilla
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
