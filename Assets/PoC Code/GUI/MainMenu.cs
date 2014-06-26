using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// GUI code
	void OnGUI()
	{
		// Menu area
		GUI.BeginGroup (new Rect ((Screen.width/2) - 100, ((Screen.height -170)/2), 200, 400));
		
			// We'll make a box so you can see where the group is on-screen.
			GUI.Box(new Rect (0,0,200,170), "" );
			
			if(GUI.Button(new Rect(10, 10, 180, 30), "New Game"))
			{
				//this.gameScreenManager.SetScreen("newGameScreen");
				this.startGame();
			}
			
			if(GUI.Button(new Rect(10, 50, 180, 30), "Load Game"))
			{
				//this.gameScreenManager.SetScreen("activityScreen");
			}
			
			if(GUI.Button(new Rect(10, 90, 180, 30), "Options"))
			{
				//this.gameScreenManager.SetScreen("activityMenu");
			}
			
			if(GUI.Button(new Rect(10, 130, 180, 30), "Exit"))
			{
				//gameScreenManager.LogData("Quitting");
				Application.Quit();
			}
		
		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
	}

	private void startGame()
	{
		print("Starting game");

		DontDestroyOnLoad(GameStateManager.Instance);
		GameStateManager.Instance.SetState("PlayingGame");
	}
}
