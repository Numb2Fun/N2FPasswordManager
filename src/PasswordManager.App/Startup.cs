using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PasswordManager.App.Startup))]
namespace PasswordManager.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
