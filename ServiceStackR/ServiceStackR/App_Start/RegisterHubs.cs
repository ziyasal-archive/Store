using System.Web;
using System.Web.Routing;
using ServiceStackR.App_Start;

[assembly: PreApplicationStartMethod(typeof(RegisterHubs), "Start")]
namespace ServiceStackR.App_Start
{
    public class RegisterHubs
    {
        public static void Start()
        {
            RouteTable.Routes.MapHubs();
        }
    }
}