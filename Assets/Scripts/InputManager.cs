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
	private KeyCode up    = KeyCode.W;
	private KeyCode left  = KeyCode.A;
	private KeyCode right = KeyCode.D;
	private KeyCode down  = KeyCode.S;

	//Action controls
	private KeyCode jump        = KeyCode.Space; 
	private KeyCode attackUp    = KeyCode.UpArrow;  
	private KeyCode attackLeft  = KeyCode.LeftArrow; 
	private KeyCode attackRight = KeyCode.RightArrow; 
	private KeyCode attackDown  = KeyCode.DownArrow; 

	
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

		if(!Input.GetKey(up) && !Input.GetKey(down) && !Input.GetKey(left) && !Input.GetKey(right)) //Se nao e nenhuma tecla de controle
			GameEventManager.post(new PlayerMoveEvent());

		if (Input.GetKey(jump)) {
			GameEventManager.post(new PlayerActionEvent(jump));
		}

		if (Input.GetKey(attackUp)) {
			GameEventManager.post(new PlayerActionEvent(attackUp));
		}
		if (Input.GetKey(attackLeft)) {
			GameEventManager.post(new PlayerActionEvent(attackLeft));
		}
		if (Input.GetKey(attackRight)) {
			GameEventManager.post(new PlayerActionEvent(attackRight));
		}
		if (Input.GetKey(attackDown)) {
			GameEventManager.post(new PlayerActionEvent(attackDown));
		}
	}
}