using System;
using System.IO;

namespace Congress
{
	public class ResourceManager
	{
		public ResourceManager ()
		{
		}

		public static void EnsureResources (System.Reflection.Assembly assembly, string dataPath) 
		{
			var contentIdentifier = assembly.GetName().Name + ".Content.";
			var scriptIdentifier = assembly.GetName().Name + ".Scripts.";
			var dataIdentifier = assembly.GetName().Name + ".App_Data.";

			foreach (var resource in assembly.GetManifestResourceNames()) {
				if (resource.StartsWith (contentIdentifier)) {
					// Treat Content resources as though every "." except the last is a directory separator
					var path = resource.Substring (contentIdentifier.Length);
					var lastDot = path.LastIndexOf (".");
					if (lastDot > -1) 
						path = path.Substring (0, lastDot).Replace ('.', Path.DirectorySeparatorChar) + "." + path.Substring (lastDot + 1);
					else
						path = path.Replace('.', Path.DirectorySeparatorChar);
					path = Path.Combine (dataPath, resource.Substring (contentIdentifier.Length));
					EnsureResource (assembly, path, resource);
				} else if (resource.StartsWith (scriptIdentifier)) {
					var path = Path.Combine (dataPath, resource.Substring (scriptIdentifier.Length));
					EnsureResource (assembly, path, resource);
				} else if (resource.StartsWith (dataIdentifier)) {
					var path = Path.Combine (dataPath, resource.Substring (dataIdentifier.Length));
					EnsureResource (assembly, path, resource);
				}
			}
		}

		public static void EnsureResource(System.Reflection.Assembly assembly, string fileName, string resource) {
			if (File.Exists (fileName))
				return;

			var directoryName = fileName.Substring (0, fileName.LastIndexOf ("/"));
			if (!Directory.Exists (directoryName))
				Directory.CreateDirectory (directoryName);

			var input = PortableRazor.ResourceLoader.GetEmbeddedResourceStream (assembly, resource);
			using (var output = new FileStream (fileName, FileMode.OpenOrCreate)) {
				byte[] buffer = new byte[1024];
				int length;
				while ((length = input.Read (buffer, 0, 1024)) > 0)
					output.Write (buffer, 0, length);
				output.Flush ();
				output.Close ();
				input.Close ();
			}
		}
	}
}

