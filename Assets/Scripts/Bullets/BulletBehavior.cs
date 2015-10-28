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

	public float TTL = 2f; //Garante a bala nao ficar para sempre no mapa
	public float Bullet1Power = 2f;

	private float passedTime;
	private float initTime;

	void Start() {
		initTime   = Time.time;
		passedTime = Time.time;
		rb = GetComponent<Rigidbody2D>();
	}

	///////////////////////////////////////////////////////////////////////////
	// CONSTANTS
	///////////////////////////////////////////////////////////////////////////

	
	void Update(){
		passedTime = Time.time;


		if (rb.velocity.Equals(new Vector2(0,0)) || (passedTime >= initTime + TTL))
	    	Destroy(gameObject); 
	}

	void OnTriggerEnter2D(Collider2D EnemyHit){
		if (EnemyHit.gameObject.tag == "Enemy") {
			var targetId = EnemyHit.gameObject.GetInstanceID();
			GameEventManager.post(new NPCHealthEvent(targetId, -Bullet1Power ));
			Destroy(gameObject); 
		}
	}

}