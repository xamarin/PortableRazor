using System;

namespace PortableRazor
{
	public interface IHybridWebView
	{
		void LoadHtmlString(string html);

		string EvaluateJavascript (string script);
	}
}

