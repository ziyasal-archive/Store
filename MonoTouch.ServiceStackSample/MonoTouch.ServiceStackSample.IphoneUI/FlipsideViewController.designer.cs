// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using MonoTouch.Foundation;

namespace MonoTouch.ServiceStackSample.IphoneUI
{
	[Register ("FlipsideViewController")]
	partial class FlipsideViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel LblData { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton BtnGetData { get; set; }

		[Action ("done:")]
		partial void done (MonoTouch.UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LblData != null) {
				LblData.Dispose ();
				LblData = null;
			}

			if (BtnGetData != null) {
				BtnGetData.Dispose ();
				BtnGetData = null;
			}
		}
	}
}
