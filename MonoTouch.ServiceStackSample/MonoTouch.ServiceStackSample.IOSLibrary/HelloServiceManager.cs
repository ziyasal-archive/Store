using ServiceStack.ServiceClient.Web;

namespace MonoTouch.ServiceStackSample.IOSLibrary
{
	public class HelloServiceManager :IHelloServiceManager
	{
		public string BaseUri {
			get;
			set;
		}
		public HelloServiceManager (string baseUri)
		{
			BaseUri = baseUri;
		}

		public string GetData(Hello request){
			JsonServiceClient client=new JsonServiceClient(BaseUri);
			var response = client.Send<HelloResponse>(request);
			return response.Result;
		}

	}
}

