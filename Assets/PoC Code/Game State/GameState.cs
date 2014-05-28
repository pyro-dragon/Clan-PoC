using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
	private static GameState instance;

	// Game state data
	private string playerName;

	// Create an istance of GameState as a game object if instance does not exist
	public static GameState Instance
	{
		get
		{
			if(instance == null)
			{
				//instance = new GameObject("GameState").AddComponent();
			}

			return instance;
		}
	}

	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}

	// Creates a new game state
	public void startState()
	{
		print ("Creating a new game state");

		// Set variable defaults
		playerName = "Player 1";

		// Load the level
		Application.LoadLevel("PoC");
	}
}
