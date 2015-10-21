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
	public  GameObject  bulletPrefab;
	private Rigidbody2D rigid;

	public  float fireRate = 1.0F;
	private float nextFire = 0.0F;


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
			    case KeyCode.UpArrow:
					FireBullet("Up"); 
					break;
			    case KeyCode.LeftArrow:
					FireBullet("Left"); 
					break;
			    case KeyCode.RightArrow:
					FireBullet("Right"); 
					break;
				case KeyCode.DownArrow:
					FireBullet("Down"); 
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
	public void FireBullet(string direction){
		if (Time.time > nextFire) { //bullet delay
			nextFire = Time.time + fireRate;

			//Clone of the bullet
			GameObject Clone;

			//spawning the bullet at position
			Clone = (Instantiate (bulletPrefab, transform.position, transform.rotation)) as GameObject;
			GameObject bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as GameObject;

			//add force to the spawned objected
			Rigidbody2D rb = Clone.GetComponent<Rigidbody2D> ();

			switch (direction) {
			case "Up":
				rb.AddRelativeForce (Vector2.up * 100);
				break;
			case "Left":
				rb.AddRelativeForce (Vector2.left * 100);
				break; 
			case "Right":
				rb.AddRelativeForce (Vector2.right * 100);
				break; 
			case "Down":
				rb.AddRelativeForce (Vector2.down * 100);
				break; 
			}
		}
		
	}
	

}