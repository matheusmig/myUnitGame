﻿//////////////////////////////////////////////////////////////////////////////
// PlayerMovement.cs
//////////////////////////////////////////////////////////////////////////////
// This script listens for PlayerMoveEvents and moves the attached object
// accordingly.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;

public class PlayerMovement : MonoBehaviour, GameEventListener 
{
	
	///////////////////////////////////////////////////////////////////////////
	// VARIABLES
	///////////////////////////////////////////////////////////////////////////
	private Rigidbody2D rigid;
	public float speed = 0.1f;

	///////////////////////////////////////////////////////////////////////////
	// CONSTANTS
	///////////////////////////////////////////////////////////////////////////

	
	///////////////////////////////////////////////////////////////////////////
	// START FUNCTION
	///////////////////////////////////////////////////////////////////////////
	
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
		GameEventManager.registerListener(this);	
	}
	
	///////////////////////////////////////////////////////////////////////////
	// EVENT LISTENING
	///////////////////////////////////////////////////////////////////////////
	
	public void eventReceived(GameEvent e)
	{
		if (e is PlayerMoveEvent)
		{
			Vector3 d = (e as PlayerMoveEvent).direction;
			
			//transform.Translate(d*moveAmount); trocado por addForce, que ja eh feito pelo sistema de fisica
			rigid.AddForce(d * speed);
		}
	}
	
}