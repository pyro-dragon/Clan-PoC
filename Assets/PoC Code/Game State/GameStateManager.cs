using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Manager of the game state
public class GameStateManager : MonoBehaviour 
{
	// The singleton instance
	private static GameStateManager instance;

	// The state list
	private Dictionary<string, GameState> stateList;
	private GameState activeState;

	// Perpectual inter-state variables
	private string playerName;

	// Create an istance of GameStateManager as a game object if instance does not exist
	public static GameStateManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("GameStateManager").AddComponent<GameStateManager>();
			}
			
			return instance;
		}
	}

	// Start the state manager
	void Start () 
	{
		playerName = "";
		activeState = null;
		InitialiseStates();
	}

	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}

	// Load a scene
	public bool LoadScene(string sceneName)
	{
		try
		{
			Application.LoadLevel(sceneName);
			return true;
		}
		catch
		{
			return false;
		}
	}

	// Get the player name
	public string GetName()
	{
		return playerName;
	}

	// Set the player name
	public void SetName(string playerName)
	{
		this.playerName = playerName;
	}

	public GameState getCurrentState()
	{
		return activeState;
	}

	public void SetState(string state)
	{
		activeState.TransitioningAway(stateList[state]);
		stateList[state].TransitioningTo(activeState);

		activeState = stateList[state];
	}

	// Initialise the states
	private void InitialiseStates()
	{
		NoGame noGame = new NoGame();
		PlayingGame playingGame = new PlayingGame();
		GamePaused gamePaused = new GamePaused();

		stateList.Add(noGame.GetName(), noGame);
		stateList.Add(playingGame.GetName(), playingGame);
		stateList.Add(gamePaused.GetName(), gamePaused);
	}
}
