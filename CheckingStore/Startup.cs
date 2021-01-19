using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckingStore.Startup))]
namespace CheckingStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
