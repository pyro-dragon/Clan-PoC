using UnityEngine;
using System.Collections;

// A state for the game to be in
public class GameState 
{
	private string stateName;			// The name of the state
	protected GameScreen currentScreen;	// The game screen to display

	// Constructor
	public GameState(string name)
	{
		stateName = name;
		currentScreen = null;
	}

	// A function to perform when the state begins
	public virtual void BeginState(GameState lastState)
	{
		
	}

	// A function to perform when the state end
	public virtual void EndState(GameState nextState)
	{

	}

	public string GetName()
	{
		return stateName;
	}
}
