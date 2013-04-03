using ServiceStack.ServiceInterface;

namespace ServiceStackR.Code
{
    public class HelloService : Service
    {
        [IncomingHub(Name = "servicelog", Method = "log")]
        [OutgoingHub(Name = "servicelog", Method = "logMessage")]
        public object Get(HelloRequest request)
        {
            return new HelloResponse { Id = 1, Name = "HelloRequest world" };
        }

        [IncomingHub(Name = "servicelog", Method = "log")]
        public void Post(HelloRequest request)
        {
        }
    }
}