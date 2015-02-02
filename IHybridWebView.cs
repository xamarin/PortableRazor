using System;

namespace PortableRazor
{
	public interface IHybridWebView
	{
		string BasePath { get; }

		void LoadHtmlString(string html);

		string EvaluateJavascript (string script);
	}
}