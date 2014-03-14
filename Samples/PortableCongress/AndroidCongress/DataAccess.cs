using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using PortableCongress;

namespace Congress
{
	public partial class DataAccess : IDataAccess
	{
		string connectionString;

		public Politician LoadPolitician (int id)
		{
			var politician = new Politician ();

			using (var connection = new SqliteConnection (connectionString)) {
				using (var cmd = connection.CreateCommand ()) {
					connection.Open ();

					//using (var cmd = new SqliteCommand ("SELECT top 1 bioguide_id, first_name, last_name,  govtrack_id, phone FROM Politician WHERE govtrack_id = @govtrack_id", connection)) {
					//	cmd.Parameters.Add (new SqliteParameter ("govtrack_id", id.ToString()));

					cmd.CommandText = String.Format ("SELECT bioguide_id, first_name, last_name, govtrack_id, phone, state, party, address FROM Politician WHERE govtrack_id = '{0}'", id);

					using (var reader = cmd.ExecuteReader ()) {
						if (reader.Read ()) {
							politician.FirstName = reader ["first_name"].ToString ();
							politician.LastName = reader ["last_name"].ToString ();
							politician.BioGuideId = reader ["bioguide_id"].ToString ();
							politician.GovTrackId = reader ["govtrack_id"].ToString ();
							politician.Phone = reader ["phone"].ToString ();
							politician.State = reader ["state"].ToString ();
							politician.Party = reader ["party"].ToString ();
							politician.OfficeAddress = reader ["address"].ToString ();
						}
					}
				}
			}
			return politician;
		}

		public List<Politician> LoadAllPoliticans ()
		{
			var politicians = new List<Politician> ();

			using (var connection = new SqliteConnection (connectionString)) {
				using (var cmd = connection.CreateCommand ()) {
					connection.Open ();
                    cmd.CommandText = String.Format ("SELECT bioguide_id, first_name, last_name,  govtrack_id, phone, party, state FROM Politician ORDER BY last_name");

					using (var reader = cmd.ExecuteReader ()) {
						while (reader.Read ()) {
							politicians.Add (new Politician { 
								FirstName = reader ["first_name"].ToString (), 
								LastName = reader ["last_name"].ToString (),
								BioGuideId = reader ["bioguide_id"].ToString (),  
								GovTrackId = reader ["govtrack_id"].ToString (), 
                                Phone = reader ["phone"].ToString (),
                                State = reader ["state"].ToString (),
                                Party = reader ["party"].ToString ()
							});
						}
					}
				}
			}
			return politicians;
		}
	}
}