using UnityEngine;
using System.Collections;

// A game state when no game is currently in progress. This is typically used to display the main menu before a game begins and after a game has been quit. 
public class NoGame : GameState 
{
	// Constructor
	public NoGame() : base("NoGame")
	{
		currentScreen = GameScreenManager
	}

	// Start state
	public override void BeginState (GameState lastState)
	{
		base.BeginState (lastState);
	}
}
