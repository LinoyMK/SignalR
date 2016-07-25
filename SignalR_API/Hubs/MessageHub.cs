using Microsoft.AspNet.SignalR;

namespace SignalR_API.Hubs
{
    public class MessageHub : Hub
    {
        public void InvokeServerMethod()
        {
            Clients.All.invokeClientMethod("Button click from client is reached in server and return to client.");
        }

        public void InvokeServerMethod(string message)
        {
            Clients.All.typedMessages(message);
        }

        #region GROUP

        public void AddToGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public void SendMessageToGroup(string message, string groupName)
        {
            Clients.Group(groupName).sendPrivateGroup(message);
        }

        #endregion
    }
}