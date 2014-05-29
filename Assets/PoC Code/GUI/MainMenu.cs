using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// GUI code
	void OnGUI()
	{



		if(GUI.Button (new Rect(30, 03, 150, 30), "Start Game"))
		{
			this.startGame();
		}
	}

	private void startGame()
	{
		print("Starting game");

		DontDestroyOnLoad(GameState.Instance);
		GameState.Instance.startState();
	}
}
