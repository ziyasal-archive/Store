using System;
using Microsoft.AspNet.SignalR;
using ServiceStack.ServiceHost;

namespace ServiceStackR.Code
{
    public class IncomingHubAttribute : Attribute, IHasRequestFilter
    {
        public string Name { get; set; }
        public string Method { get; set; }

        public void RequestFilter(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Method)) return;
            var hub = GlobalHost.ConnectionManager.GetHubContext(Name);

            if (hub != null)
            {
                hub.Clients.All.Invoke(Method,
                       new
                       {
                           Time = DateTime.Now.ToString("G"),
                           Data = req.HttpMethod + " " + req.RawUrl + " " + req.GetRawBody()
                       });
            }
        }

        public IHasRequestFilter Copy()
        {
            return this;
        }

        public int Priority
        {
            get
            {
                return -1;
            }
        }
    }
}