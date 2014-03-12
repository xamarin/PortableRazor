using System;
using Android.App;
using Android.Webkit;
using PortableRazor;
using PortableCongress;

namespace AndroidCongress
{
	class HybridWebView : IHybridWebView {
		WebView webView;

		public HybridWebView(WebView uiWebView) {
			webView = uiWebView;
		}

		#region IHybridWebView implementation

		public void LoadHtmlString (string html)
		{
			var datapath = String.Format ("/data/data/{0}/files/", Application.Context.PackageName);
			var url = "file://" + datapath;
			webView.LoadDataWithBaseURL(url, html, "text/html", "UTF-8", null);
		}

		public string EvaluateJavascript (string script) 
		{
			webView.LoadUrl ("javascript:" + script);
			return "";
		}

		#endregion
	}
}

