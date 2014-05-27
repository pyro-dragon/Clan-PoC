using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// GUI code
	void onGUI()
	{
		if(GUI.Button (new Rect(30, 03, 150, 30), "Start Game"))
		{
			startGame();
		}
	}

	private void starGame()
	{
		print("Starting game");

		DontDestroyOnLoad(GameStateManager.Instantiate);
		GameStateManager.Instantiate.startState();
	}
}
