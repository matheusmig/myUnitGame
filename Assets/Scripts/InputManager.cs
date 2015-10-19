//////////////////////////////////////////////////////////////////////////////
// InputManager.cs
//////////////////////////////////////////////////////////////////////////////
// This object polls Unity for input and posts relevant GameEvents.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;

public class InputManager : MonoBehaviour
{
	///////////////////////////////////////////////////////////////////////////
	// CLASS DATA
	///////////////////////////////////////////////////////////////////////////
	
	//Keycodes for controls
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode down = KeyCode.DownArrow;
	
	///////////////////////////////////////////////////////////////////////////
	// FIXED UPDATE
	///////////////////////////////////////////////////////////////////////////
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKey(up))
			GameEventManager.post(new PlayerMoveEvent(Vector3.up, up));
		
		if(Input.GetKey(left))
			GameEventManager.post(new PlayerMoveEvent(Vector3.left, left));
		
		if(Input.GetKey(right))
			GameEventManager.post(new PlayerMoveEvent(Vector3.right, right));
		
		if(Input.GetKey(down))
			GameEventManager.post(new PlayerMoveEvent(Vector3.down, down));

		if(!Input.anyKey)
			GameEventManager.post(new PlayerMoveEvent());


	}
}