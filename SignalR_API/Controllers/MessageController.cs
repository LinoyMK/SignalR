using Microsoft.AspNet.SignalR;
using SignalR_API.Hubs;
using System.Web.Http;

namespace SignalR_API.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        private readonly IHubContext _hubContext;
        public MessageController()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
        }

        [HttpGet]
        [Route("publish/{message}")]
        public bool GetPublishMessage(string message)
        {
            _hubContext.Clients.All.pushMessage(message + "XXX");
            return true;
        }
        
    }
}
