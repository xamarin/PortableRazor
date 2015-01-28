using System;
using System.IO;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper {

		public IHtmlString ActionLink(string linkText, string actionName, object routeValues = null, object htmlAttributes = null) {
			return ActionLink (linkText, actionName, String.Empty, routeValues, htmlAttributes);
		}

		public IHtmlString ActionLink(string linkText, string actionName, string controllerName = "", object routeValues = null, object htmlAttributes = null) {
			var qs = UrlHelper.GenerateQueryString (routeValues);
			if (qs.Length > 0)
				qs = "?" + qs;

			return new HtmlString(string.Format ("<a href=\"{0}{1}{2}{3}\"{4}>{5}</a>",
				ViewBase.UrlScheme,
				string.IsNullOrEmpty(controllerName) ? String.Empty : controllerName + "/",
				actionName, 
				qs,
				GenerateHtmlAttributes(htmlAttributes), 
				linkText));
		}

	}
}

