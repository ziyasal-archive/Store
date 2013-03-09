using Nancy;

namespace NancyFxR
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = p => View["Home.html"];
        }
    }
}