using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvengersUnityIdentity.Startup))]
namespace AvengersUnityIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
