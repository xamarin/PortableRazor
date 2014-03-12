using System;
using PortableRazor;

namespace PortableCongress
{
	public class PoliticianController
	{
		IHybridWebView webView;
	    IDataAccess dataAccess;

		public PoliticianController (IHybridWebView webView, IDataAccess dataAccess)
		{
			this.webView = webView;
			this.dataAccess = dataAccess;
		}

		public void ShowPoliticianList() {
			var list = dataAccess.LoadAllPoliticans ();

			var template = new PoliticianList () { Model = list };
			var page = template.GenerateString ();

			webView.LoadHtmlString (page);
		}

		public Politician ShowPoliticianView(int id) {
			var politician = dataAccess.LoadPolitician (id);

			var template = new PoliticianView () { Model = politician };
			var page = template.GenerateString ();

			webView.LoadHtmlString (page);
			return politician;
		}

		public async void ShowRecentVotes(int id) {
			//var votes = dataAccess.LoadRecentVotes (id);
			var votes = await WebAccess.GetRecentVotesAsync (id);

			var template = new RecentVotesList () { Model = votes };
			var page = template.GenerateString ();

			webView.LoadHtmlString (page);
		}
	}
}

