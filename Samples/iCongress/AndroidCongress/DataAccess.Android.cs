using System;
using System.IO;
using Android.App;

namespace Congress
{
	public partial class DataAccess
	{
		public DataAccess() {
			var dbName = "congress.sqlite";
			var dataPath = String.Format ("/data/data/{0}/files", Application.Context.PackageName);
			connectionString = String.Format("URI=file:{0}", Path.Combine (dataPath, dbName));
		}
	}
}

