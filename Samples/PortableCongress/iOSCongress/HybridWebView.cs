using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PortableCongress;
using PortableRazor;

namespace iOSCongress
{
	class HybridWebView : IHybridWebView {
		UIWebView webView;

		public HybridWebView(UIWebView uiWebView) {
			webView = uiWebView;
		}

		#region IHybridWebView implementation

		public void LoadHtmlString (string html)
		{
			var url = new NSUrl (Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), true);
			webView.LoadHtmlString (html, url);
		}

		public string EvaluateJavascript (string script) 
		{
			return webView.EvaluateJavascript (script);
		}

		#endregion
	}
}

