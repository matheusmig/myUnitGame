//////////////////////////////////////////////////////////////////////////////
// PlayerActionEvent
//////////////////////////////////////////////////////////////////////////////
// This event is dispatched when an action key is pressed.
// Action refers to: Jump, Attack, Defend, Use Skills... (not movement!) 
//////////////////////////////////////////////////////////////////////////////

//default namespaces
using UnityEngine;
using System.Collections;

//Add access to game events classes
using GameEvents;

//PlayerMoveEvent is a GameEvent
public class PlayerActionEvent : GameEvent
{
	///////////////////////////////////////////////////////////////////////////
	// EVENT DATA
	///////////////////////////////////////////////////////////////////////////
	public KeyCode pressedKey;
	
	///////////////////////////////////////////////////////////////////////////
	// CONSTRUCTOR
	///////////////////////////////////////////////////////////////////////////
	public PlayerActionEvent(KeyCode k)
	{
		pressedKey = k; 
	}

}