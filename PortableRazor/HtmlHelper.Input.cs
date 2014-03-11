using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper
	{
		#region CheckBox
		public IHtmlString CheckBox (string name) {
			return Input("checkbox", name);
		}

		public IHtmlString CheckBox (string name, bool isChecked) {
			return Input("checkbox", name, isChecked:isChecked);
		}

		public IHtmlString CheckBox (string name, object htmlAttributes) {
			return Input("checkbox", name, htmlAttributes: htmlAttributes);
		}

		public IHtmlString CheckBox (string name, bool isChecked, object htmlAttributes) {
			return Input("checkbox", name, isChecked:isChecked, htmlAttributes: htmlAttributes);
		}
		#endregion

		#region Hidden
		public IHtmlString Hidden (string name) {
			return Input("hidden", name);
		}

		public IHtmlString Hidden (string name, object value) {
			return Input("hidden", name, value);
		}

		public IHtmlString Hidden (string name, object value, object htmlAttributes) {
			return Input("hidden", name, value, htmlAttributes: htmlAttributes);
		}

		public IHtmlString Hidden (string name, object value, string format) {
			return Input("hidden", name, value, format);
		}

		public IHtmlString Hidden (string name, object value, string format, object htmlAttributes) {
			return Input("hidden", name, value, format, htmlAttributes);
		}
		#endregion

		#region Password
		public IHtmlString Password (string name) {
			return Input("password", name);
		}

		public IHtmlString Password (string name, object value) {
			return Input("password", name, value);
		}

		public IHtmlString Password (string name, object value, object htmlAttributes) {
			return Input("password", name, value, htmlAttributes: htmlAttributes);
		}
		#endregion

		#region RadioButton
		public IHtmlString RadioButton (string name, object value) {
			return Input("radio", name, value);
		}

		public IHtmlString RadioButton (string name, object value, bool isChecked) {
			return Input("radio", name, value, isChecked:isChecked);
		}

		public IHtmlString RadioButton (string name, object value, object htmlAttributes) {
			return Input("radio", name, value, htmlAttributes: htmlAttributes);
		}

		public IHtmlString RadioButton (string name, object value, bool isChecked, object htmlAttributes) {
			return Input("radio", name, value, isChecked:isChecked, htmlAttributes: htmlAttributes);
		}
		#endregion

		#region TextBox
		public IHtmlString TextBox (string name) {
			return Input("text", name);
		}

		public IHtmlString TextBox (string name, object value) {
			return Input("text", name, value);
		}

		public IHtmlString TextBox (string name, object value, object htmlAttributes) {
			return Input("text", name, value, htmlAttributes: htmlAttributes);
		}
			
		public IHtmlString TextBox (string name, object value, string format) {
			return Input("text", name, value, format);
		}

		public IHtmlString TextBox (string name, object value, string format, object htmlAttributes) {
			return Input("text", name, value, format, htmlAttributes);
		}
		#endregion

		private IHtmlString Input (string inputType, string name, object value = null, string format = "{0}", object htmlAttributes = null, bool isChecked = false) {

			var formattedValue = value != null ? String.Format(format, value) : null;

			return new HtmlString(string.Format ("<input type=\"{0}\" name=\"{1}\" id=\"{1}\"{2}{3}{4} />", 
				inputType, 
				name,
				formattedValue == null ? String.Empty : String.Format("value=\"{0}\"", formattedValue),
				isChecked ? " checked=\"checked\"" : String.Empty,
				GenerateHtmlAttributes (htmlAttributes)));
		}
	}
}

