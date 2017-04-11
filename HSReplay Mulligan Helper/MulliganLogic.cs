using System;
using System.Linq;
using System.Threading.Tasks;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using HtmlAgilityPack;
using System.Windows;
using System.Web;
using Hearthstone_Deck_Tracker.Importing;
using Hearthstone_Deck_Tracker.Utility.Logging;

namespace HSReplay_Mulligan_Helper
{
	public class MulliganLogic
	{
		public static MulliganLogic Instance => _instance ?? (_instance = new MulliganLogic());
		private static MulliganLogic _instance;

		public bool ShouldShow;
		private HtmlDocument _doc;

		internal void TurnStart(ActivePlayer player)
		{
			Instance.ShouldShow = false;
		}

		internal void GameStart()
		{
			Instance.ShouldShow = true;
		}

		internal void Mulligan(Hearthstone_Deck_Tracker.Hearthstone.Card f)
		{
			MessageBox.Show(f.EnglishText);
		}

		private string ActiveDeckUrl() => DeckList.Instance.ActiveDeck.Url;

		private async Task<string> MulliganWinrate(string cardName)
		{
			try
			{
				if(_doc == null)
					_doc = await ImportingHelper.GetHtmlDoc(ActiveDeckUrl());
				
				
				var ournode = _doc.DocumentNode.SelectNodes("//span[@class=\"card-name\"]").First(x => x.InnerText == cardName);
				return HttpUtility.HtmlDecode(ournode.SelectSingleNode("//ancestor::tr/td[@class=\"winrate-cell\"][1]").InnerText);
			}
			catch (Exception ex)
			{
				Log.Error("Unable to get Mulligan Winrate ->");
				Log.Error(ex);
				return "error";
			}
		}
	}
}
