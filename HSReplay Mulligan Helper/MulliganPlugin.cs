using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace HSReplay_Mulligan_Helper
{
    public class MulliganPlugin : IPlugin
    {
	    public void OnLoad()
	    {
		    GameEvents.OnTurnStart.Add(MulliganLogic.Instance.TurnStart);
			GameEvents.OnGameStart.Add(MulliganLogic.Instance.GameStart);
			GameEvents.OnPlayerMulligan.Add(MulliganLogic.Instance.Mulligan);
	    }

	    public void OnUnload()
	    {
		    
	    }

	    public void OnButtonPress()
	    {
		    
	    }

	    public void OnUpdate()
	    {
		    
	    }

	    public string Name => "HSReplay Mulligan Helper";
	    public string Description => "Shows you the statistics of certain cards in your mulligan phase when the current deck was imported via HSReplay.\n\nMake sure the current active deck's URL is HSreplay to enable usage.";
		public string ButtonText => "Settings (TBD)";
		public string Author => "Judge2020";
		public Version Version => new Version(0, 0, 1);
	    public MenuItem MenuItem => null;
    }
}
