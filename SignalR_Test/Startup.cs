using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR_Test.Startup))]

namespace SignalR_Test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
