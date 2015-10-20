using UnityEngine;
using System.Collections;
using GameEvents;

public class PlayerHealth : MonoBehaviour, GameEventListener{
    

	public float Health;
	public float MaxHealth;
    private float healthChange = 0;

	private float HitTime;
	private float HitDelay = 0.5f;

	void Start () {
		MaxHealth = 100;
		Health = 100;
		HitTime = Time.time;
        GameEventManager.registerListener(this);
    }

    ///////////////////////////////////////////////////////////////////////////
    // EVENT LISTENING
    //////////////////////////////////////////////////////////////////////////

    public void eventReceived(GameEvent e)
    {
        if (e is PlayerHealthEvent)
        {
            float healthChange = (e as PlayerHealthEvent).playerHealth;
            Health += healthChange;
            if (Health <= 0)
                Health = 0;
            //Debug.Log("HealthChange: " + healthChange);
        }
    }




    ///////////////////////////////////////////////////////////////////////////
    // Update health is called once per frame
    //////////////////////////////////////////////////////////////////////////

    void Update () {
		if (Health <= 0) {
			Debug.Log ("GAME OVER, YOU'RE DEAD");
		}

		if (Health > MaxHealth) {
			Health = MaxHealth;
		}
	
		Debug.Log (" HP: "+ Health.ToString());
	}

	void OnCollisionStay2D (Collision2D EnemyHit){
		Debug.Log (EnemyHit.gameObject.tag);
		if (EnemyHit.gameObject.tag == "Enemy") {
			if (HitTime + HitDelay < Time.time){
				HitTime = Time.time;
				Health -= 1;

			}

			float verticalPush    = EnemyHit.gameObject.transform.position.y - transform.position.y;
			float horizontalPush  = EnemyHit.gameObject.transform.position.x - transform.position.x;
		}
	}

   


}
