using System;

namespace PortableCongress
{
	public class Politician
	{
		public string Name { get; set; }
		public string BioGuideId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OfficeAddress { get; set; }
		public string GovTrackId { get; set; }
		public string Phone {get; set; }
		public string TwitterId { get; set; }
		public string YoutubeUrl { get; set; }
		public string WebSite { get; set; }
		public string Party { get; set; }
		public string State { get; set; }

		int id;
		public int Id {
			get {
				id = int.Parse (GovTrackId);
				return id;
			}
			set{ id = value; }
		}

		string imageName;
		public string ImageName { 
			get{
				imageName = String.Format("https://www.govtrack.us/data/photos/{0}-100px.jpeg", GovTrackId);
				return imageName;
			}
			set{
				imageName = value;
			}
		}
	}
}