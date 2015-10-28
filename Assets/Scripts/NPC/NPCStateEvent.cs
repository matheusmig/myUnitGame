﻿//////////////////////////////////////////////////////////////////////////////
// NPCStateEvent
//////////////////////////////////////////////////////////////////////////////
// This event is dispatched when the vegetal state is changed.
//////////////////////////////////////////////////////////////////////////////

//default namespaces
using UnityEngine;
using System.Collections;

//Add access to game events classes
using GameEvents;

//NPCHealthEvent is a GameEvent
public class NPCStateEvent : GameEvent
{

    ///////////////////////////////////////////////////////////////////////////
    // EVENT DATA
    ///////////////////////////////////////////////////////////////////////////
	public int NPCInstanceID;
    public int NPCState;

    ///////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////

    public NPCStateEvent(int id, int state)
    {
		NPCInstanceID = id;
		NPCState = state;
    }
}