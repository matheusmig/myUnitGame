//////////////////////////////////////////////////////////////////////////////
// PlayerMovement.cs
//////////////////////////////////////////////////////////////////////////////
// This script listens for PlayerActionEvents and make actions accordly the 
// presse key
//////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using GameEvents;

public class PlayerAction : MonoBehaviour, GameEventListener 
{
	
	///////////////////////////////////////////////////////////////////////////
	// VARIABLES
	private Rigidbody2D rigid;
	public  GameObject  bulletPrefab;


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
		if (e is PlayerActionEvent)
		{
			KeyCode pressedKey = (e as PlayerActionEvent).pressedKey;
			
			switch (pressedKey){
				case KeyCode.Space:
					Debug.Log ("ESPAÇOOOOOOOOOOOOOOOOOOO");
					break;
				case KeyCode.A:
					FireBullet(); 
					break;
				default : 
					Debug.Log(pressedKey.GetTypeCode());
					break;
			}
		}
	}

	///////////////////////////////////////////////////////////////////////////
	// ACTION FUNCTIONS
	///////////////////////////////////////////////////////////////////////////
	public void FireBullet(){
		//Clone of the bullet
		GameObject Clone;

		//spawning the bullet at position
		Clone = (Instantiate(bulletPrefab, transform.position,transform.rotation)) as GameObject;
		GameObject bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;

		//add force to the spawned objected
		Rigidbody2D rb = Clone.GetComponent<Rigidbody2D>();

		rb.AddRelativeForce(rigid.velocity * 100 );


		Debug.Log ("Force is added");
		
	}
	
}