﻿using Microsoft.AspNet.SignalR;
using Nancy;

namespace NancyFxR
{
    public class PushModule : NancyModule
    {
        public PushModule()
            : base("/push")
        {
            Get["/{message}"] = p =>
            {
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NancyHub>();
                hubContext.Clients.All.SayHello(new { message = string.Format("Pushed :{0}", p.message) });
                return Response.AsJson(new { message = "Pushed.." });
            };
        }
    }
}