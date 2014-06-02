using UnityEngine;
using System.Collections;

// A state for the game to be in
public class GameState 
{
	private string stateName;	// The name of the state

	// Constructor
	public GameState(string name)
	{
		stateName = name;
	}

	// A function to perform just before this state is transitioned away from
	public virtual void TransitioningAway(GameState nextState)
	{
		
	}

	// A function to perform before the state is transitioned into
	public virtual void TransitioningTo(GameState previouseState)
	{

	}

	public string GetName()
	{
		return stateName;
	}
}
