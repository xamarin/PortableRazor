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
			webView.EvaluateJavascript ("$.mobile.loading( 'show', {\n  text: 'Loading Recent Votes ...',\n  " +
				"textVisible: 'false',\n  theme: 'b',\n  textonly: 'false' });");

			var votes = await WebAccess.GetRecentVotesAsync (id);

			var template = new RecentVotesList () { Model = votes };
			var page = template.GenerateString ();

			webView.LoadHtmlString (page);
		}

		public async void ShowCommittees(int id, string bioguideid) {
			webView.EvaluateJavascript ("$.mobile.loading( 'show', {\n  text: 'Loading Committees ...',\n  " +
				"textVisible: 'false',\n  theme: 'b',\n  textonly: 'false' });");

			var committees = await WebAccess.GetCommitteesAsync (id, bioguideid);

			var template = new CommitteeList { Model = committees };
			var page = template.GenerateString ();

			webView.LoadHtmlString (page);
		}
	}
}

