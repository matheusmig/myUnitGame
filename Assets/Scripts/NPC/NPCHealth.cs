using UnityEngine;
using System.Collections;
using GameEvents;

public class NPCHealth : MonoBehaviour, GameEventListener {

    public float NPCHealthLvl;
    public float NPCMaxHealth;
    private float NPCHealthChange;

    private float HitTime;
    private float HitDelay = 0.5f;

    void Start() {
        //MaxHealth = 2000;
        //Health = 2000;
        HitTime = Time.time;
        GameEventManager.registerListener(this);
    }

    ///////////////////////////////////////////////////////////////////////////
    // EVENT LISTENING
    //////////////////////////////////////////////////////////////////////////

    public void eventReceived(GameEvent e) {
        if (e is NPCHealthEvent) {
			NPCHealthEvent evento = (e as NPCHealthEvent);

			///////////////////////////////////////
			/// Confere se foi o monstro alvo
			var selfID = gameObject.GetInstanceID();
			if (selfID == evento.NPCInstanceID){

				NPCHealthChange = evento.NPCHealth;

	            if ((NPCHealthLvl >= NPCMaxHealth / 2) && (NPCHealthLvl+NPCHealthChange < NPCMaxHealth / 2))
					GameEventManager.post(new NPCStateEvent(selfID, 2)); //dispara o evento de transformação do inimigo em Vegetal. Esse evento será disparado com o efeito do antidoto

	            if ((NPCHealthLvl < NPCMaxHealth / 2) && (NPCHealthLvl + NPCHealthChange >= NPCMaxHealth / 2))
					GameEventManager.post(new NPCStateEvent(selfID, 1)); //dispara o evento de transformação do vegetal em Inimigo. Esse evento será disparado pelo efeito do veneno no ataque dos inimigos no vegetal, que poderá transformar-lo novamente em vegetalInimigo
	            
				NPCHealthLvl += NPCHealthChange;
				if (NPCHealthLvl <= 0){
					Die ();
					NPCHealthLvl = 0;  
				}

				///////////////////////////////////////////////////////////////////
				/// Exibe Dano
				var selfTransform = GetComponent<Transform> ();
				DamagePopUp.ShowMessage (NPCHealthChange.ToString(), selfTransform.position);
			}
        }
    }




    ///////////////////////////////////////////////////////////////////////////
    // Update health is called once per frame
    //////////////////////////////////////////////////////////////////////////

    void Update() {
		var self = gameObject;

        /*if (NPCHealthLvl <= 0) {

			GameEventManager.post(new NPCStateEvent(self.GetInstanceID(), 2));
            Debug.Log("GAME OVER, YOU Will SUFFOCATE WITHOUT OXYGEN!!");
        }*/

        if (NPCHealthLvl > NPCMaxHealth) {
            NPCHealthLvl = NPCMaxHealth;
        }

      /*  if (NPCHealthLvl < NPCMaxHealth/2)
        {
            GameEventManager.post(new NPCStateEvent(self.GetInstanceID(), 2));
        }*/

    }

	void Die(){
		Destroy (gameObject); 
	}
    
}
