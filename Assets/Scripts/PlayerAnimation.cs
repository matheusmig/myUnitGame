using UnityEngine;
using System.Collections;
using GameEvents;

public class PlayerAnimation : MonoBehaviour, GameEventListener {

	private Animator anim;
	bool isFacingLeft;

	///////////////////////////////////////////////////////////////////////////
	// START FUNCTION
	///////////////////////////////////////////////////////////////////////////
	void Start () 
	{
		isFacingLeft = false; //o personagem sempre começa virado para direita
		anim = GetComponent<Animator>();
		GameEventManager.registerListener(this);	
	}
	
	///////////////////////////////////////////////////////////////////////////
	// EVENT LISTENING
	///////////////////////////////////////////////////////////////////////////
	
	public void eventReceived(GameEvent e)
	{
		if (e is PlayerMoveEvent)
		{

			KeyCode k = (e as PlayerMoveEvent).pressedKey;
			string strKeyPressed = k.ToString();

			switch (strKeyPressed){
			case "A":
				Flip ("left");
				anim.SetBool("Idle",false);
				anim.SetBool("WalkRight",false); 
				anim.SetBool("WalkLeft",true); 
				break;
			case "D": 
				Flip ("right");
				anim.SetBool("Idle",false); 
				anim.SetBool("WalkRight",true); 
				anim.SetBool("WalkLeft",false); 
				break;
			default: 
				anim.SetBool("Idle",true); 
				anim.SetBool("WalkRight",false); 
				anim.SetBool("WalkLeft",false); 
				break;
			}
		}

		if (e is PlayerActionEvent) {
			KeyCode k = (e as PlayerActionEvent).pressedKey;

		}
	}

	///////////////////////////////////////////////////////////////////////////
	// Inverte posicao da animacao
	///////////////////////////////////////////////////////////////////////////
	protected void Flip(string side)    
	{	

		if (side == "left" && !isFacingLeft) {
			//Debug.Log ("virou pra esquerda");
			isFacingLeft = true;
			anim.transform.localScale = new Vector3(-1, 1, 1);
		} else if (side == "right" && isFacingLeft) {
			//Debug.Log ("virou pra direita");
			isFacingLeft = false;
			anim.transform.localScale = new Vector3(1, 1, 1);
		}

	}
	

}
