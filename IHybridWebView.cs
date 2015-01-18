using System;

namespace PortableRazor
{
	public interface IHybridWebView
	{
		string BasePath { get; set; }

		void LoadHtmlString(string html);

		string EvaluateJavascript (string script);
	}
}