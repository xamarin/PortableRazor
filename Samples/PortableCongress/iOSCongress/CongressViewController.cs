using System;
using System.Drawing;
using System.Reflection;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Congress;
using PortableCongress;

namespace iOSCongress
{
	public partial class CongressViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public CongressViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			webView.ShouldStartLoad += HandleShouldStartLoad;

			var politicianController = new PoliticianController (
				                        new HybridWebView (webView), 
				                        new DataAccess ());

			PortableRazor.RouteHandler.RegisterController ("Politician", politicianController);

			politicianController.ShowPoliticianList ();
		}
			
		bool HandleShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType) {
			var handled = PortableRazor.RouteHandler.HandleRequest (request.Url.AbsoluteString);
			return !handled;
		}
	}
}

