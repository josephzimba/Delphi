using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Delphi.Startup))]
namespace Delphi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
