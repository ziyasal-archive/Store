using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ServiceStackR.Code
{
    [HubName("servicelog")]
    public class LogHub : Hub
    { }
}