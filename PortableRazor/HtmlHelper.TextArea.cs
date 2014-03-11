using System;
using System.IO;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper
	{
		public IHtmlString TextArea(string name, object htmlAttributes) {
			return TextArea (name, value: "", htmlAttributes: htmlAttributes);
		}

		public IHtmlString TextArea(string name, string value, object htmlAttributes) {
			return TextArea (name, value: value, htmlAttributes: htmlAttributes);		
		}

		public IHtmlString TextArea(string name, string value = "", int rows = -1, int columns = -1, object htmlAttributes = null){
			return new HtmlString (string.Format ("<textarea name=\"{1}\" id=\"{1}\"{2}{3}{4}>{0}</textarea>", 
				value,
				name,
				rows > -1 ? String.Format ("rows=\"{0}\"", rows) : String.Empty,
				columns > -1 ? String.Format ("cols=\"{0}\"", columns) : String.Empty,
				GenerateHtmlAttributes (htmlAttributes)));
		}
	}
}

