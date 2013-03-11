using System;
using MonoTouch.ServiceStackSample.IOSLibrary;
using MonoTouch.UIKit;
//using PortableLibraryDemo;


namespace MonoTouch.ServiceStackSample.IphoneUI
{

	public partial class FlipsideViewController : UIViewController
	{
		public FlipsideViewController () : base ("FlipsideViewController", null)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			BtnGetData.TouchDown += delegate(object sender, EventArgs e) {
				LblData.Text="Loading data...";

				IHelloServiceManager manager=new HelloServiceManager("http://www.servicestack.net/ServiceStack.Hello/servicestack/json/syncreply/Hello");
				LblData.Text=manager.GetData(new Hello { Name = "Ziyasal!" });
				/*JsonServiceClient client=new JsonServiceClient("http://www.servicestack.net/ServiceStack.Hello/servicestack/json/syncreply/Hello");
				var response = client.Send<HelloResponse>(new Hello { Name = "Ziyasal!" });
				LblData.Text=response.Result;*/

			};
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		partial void done (UIBarButtonItem sender)
		{
			if (Done != null)
				Done (this, EventArgs.Empty);
		}
		
		public event EventHandler Done;
	}
}

