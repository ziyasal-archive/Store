using ServiceStack.ServiceClient.Web;

namespace MonoTouch.ServiceStackSample.PortableLibrary
{
	public class PortableHelloServiceManager :IPortableHelloServiceManager
	{
		public string BaseUri {
			get;
			set;
		}
		public PortableHelloServiceManager (string baseUri)
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

