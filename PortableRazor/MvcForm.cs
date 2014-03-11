using System;
using System.IO;
using System.Reflection;

namespace PortableRazor.Web.Mvc
{
	public class MvcForm : IDisposable {
		private bool _disposed;
		private TextWriter _writer;
		private string _elementName;

		public MvcForm(TextWriter writer, string elementName) {
			_writer = writer;
			_elementName = elementName;
		}

		#region IDisposable implementation
		public void Dispose ()
		{
			Dispose(true);
			GC.SuppressFinalize(this); 
		}

		protected virtual void Dispose (bool disposing)
		{
			if (!_disposed) {
				_disposed = true;
				_writer.Write (string.Format("</{0}>", _elementName));
			}
		}

		#endregion
	}
}

