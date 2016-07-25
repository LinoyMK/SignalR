using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SignalR_API.Startup))]

namespace SignalR_API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

            app.MapSignalR();
        }
    }
}
