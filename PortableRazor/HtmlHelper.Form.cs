using System;
using System.IO;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper {

		public enum FormMethod { Get , Post };

		public MvcForm BeginForm(string actionName = "", string controllerName = "", object routeValues = null, FormMethod method = FormMethod.Get, object htmlAttributes = null) {
			var qs = UrlHelper.GenerateQueryString (routeValues);
			if (qs.Length > 0)
				qs = "?" + qs;

			var form = String.Format ("<form action=\"{0}{1}{2}{3}\" method=\"{4}\"{5}>", 
				ViewBase.UrlScheme,
                String.IsNullOrEmpty (controllerName) ? String.Empty : controllerName + "/", 
                actionName, 
				qs, 
				method == FormMethod.Post ? "post" : "get",
				GenerateHtmlAttributes(htmlAttributes));
			_writer.Write (form);
			return new MvcForm (_writer, "form");
		}
	}
}

