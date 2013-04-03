using Funq;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStackR.Code
{
    public class HelloAppHost : AppHostBase
    {
        public HelloAppHost()
            : base("HelloRequest Web Services", typeof(HelloService).Assembly)
        {
            PreRequestFilters.Add((req, res) => req.UseBufferedStream = true);
        }

        public override void Configure(Container container)
        {
            Routes
                .Add<HelloRequest>("/hello")
                .Add<HelloRequest>("/hello/{Name}");
        }
    }
}