using UnityEngine;
using System.Collections;
using GameEvents;

//********************************************************************************
//  Realiza o ataque dos NPCs vegetais
//
//
//
//*********************************************************************************

public class BulletBehavior : MonoBehaviour {
	private Rigidbody2D rb;
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	///////////////////////////////////////////////////////////////////////////
	// CONSTANTS
	///////////////////////////////////////////////////////////////////////////
	const float Bullet1Power = 1.5f;
	
	void Update(){
		Debug.Log (rb.velocity);
	  if (rb.velocity.Equals(new Vector2(0,0)))
	    Destroy(gameObject); 
	}

	void OnTriggerEnter2D(Collider2D EnemyHit){
		if (EnemyHit.gameObject.tag == "Enemy") {
			GameEventManager.post(new NPCHealthEvent( -Bullet1Power ));
			Destroy(gameObject); 
		}
	}

}