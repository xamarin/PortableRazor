using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace PortableCongress
{
	public class WebAccess
	{
		public WebAccess ()
		{
		}

		public static async Task<RecentVotes> GetRecentVotesAsync(int id)
		{
			using (var httpClient = new HttpClient())
			{
				string url = String.Format ("http://www.govtrack.us/users/events-rss2.xpd?monitors=pv:{0}&days=30", id);

				var response = await httpClient.GetAsync(url);
				var stream  = await response.Content.ReadAsStreamAsync();
				var votes = LoadVotes (stream);
				var recentVotes = new RecentVotes {Id = id, Votes = votes};

				return recentVotes;
			}
		}

		static List<Vote> LoadVotes (Stream stream)
		{
			XDocument voteFeed = XDocument.Load (stream);

			var votes = (from item in voteFeed.Descendants ("item")
				select new Vote {
					Title = item.Element ("title").Value,
					PublicationDate = DateTime.Parse (item.Element ("pubDate").Value),
					Link = item.Element ("link").Value,
					Description = item.Element ("description").Value
				}).OrderByDescending (v =>  v.PublicationDate).ToList();

			return votes;
		}
	}
}

