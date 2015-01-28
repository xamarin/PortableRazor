using System;
using System.Reflection;
using System.Text;

namespace PortableRazor.Web.Mvc
{
	public class UrlHelper
	{
		public UrlHelper ()
		{
		}

		public string Action(string actionName, object routeValues) {
			return Action(actionName, controllerName: null, routeValues: routeValues);
		}

		public string Encode(string url) {
			return System.Net.WebUtility.UrlEncode (url);
		}

        public string Content(string contentPath){

            //ASP.NET MVC calls this -> return GenerateContentUrl(contentPath, RequestContext.HttpContext);

            return contentPath; //TODO: implement this method
		}

		public string Action(
			string actionName, 
			string controllerName = "", 
			object routeValues = null, 
			string scheme = "", 
			string hostName = "") {

			if (String.IsNullOrEmpty(scheme))
				scheme = ViewBase.UrlScheme;

			var qs = GenerateQueryString (routeValues);
			if (qs.Length > 0)
				qs = "?" + qs;

			return string.Format ("{0}{1}{2}{3}{4}", 
				scheme,
				String.IsNullOrEmpty(hostName) ? String.Empty : hostName + ".",
				String.IsNullOrEmpty(controllerName) ? String.Empty : controllerName + "/",
				actionName, 
				qs);
		}

		public static string GenerateQueryString(object routeValues = null) {
			if (routeValues == null)
				return String.Empty;

			var qs = new StringBuilder ();
			foreach (var property in routeValues.GetType ().GetRuntimeProperties()) 
				qs.AppendFormat ("&{0}={1}", property.Name, property.GetMethod.Invoke (routeValues, null));

			if (qs.Length == 0)
				return String.Empty;

			return qs.ToString (1, qs.Length - 1);
		}
	}
}

