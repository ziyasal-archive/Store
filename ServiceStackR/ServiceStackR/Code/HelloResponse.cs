using ServiceStack.ServiceHost;

namespace ServiceStackR.Code
{
    [Route("/hello")]
    public class HelloResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}