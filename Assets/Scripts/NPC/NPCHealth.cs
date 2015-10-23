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
            NPCHealthChange = (e as NPCHealthEvent).NPCHealth;
            if ((NPCHealthLvl >= NPCMaxHealth / 2) && (NPCHealthLvl+NPCHealthChange < NPCMaxHealth / 2))
                GameEventManager.post(new NPCStateEvent(2)); //dispara o evento de transformação do inimigo em Vegetal. Esse evento será disparado com o efeito do antidoto
            if ((NPCHealthLvl < NPCMaxHealth / 2) && (NPCHealthLvl + NPCHealthChange >= NPCMaxHealth / 2))
                GameEventManager.post(new NPCStateEvent(1)); //dispara o evento de transformação do vegetal em Inimigo. Esse evento será disparado pelo efeito do veneno no ataque dos inimigos no vegetal, que poderá transformar-lo novamente em vegetalInimigo
            NPCHealthLvl += NPCHealthChange;
			DamagePopUp.ShowMessage (NPCHealthChange.ToString(), transform.position);  
            if (NPCHealthLvl <= 0)
                NPCHealthLvl = 0;   

			/////////////////
			/// PopUp Damage
			var selfTransform = GetComponent<Transform> ();
			DamagePopUp.ShowMessage (NPCHealthChange.ToString(), selfTransform.position);
            
            //DamagePopUp.ShowMessage (NPCHealthLvl.ToString(), selfTransform.position);
        }
    }




    ///////////////////////////////////////////////////////////////////////////
    // Update health is called once per frame
    //////////////////////////////////////////////////////////////////////////

    void Update() {
        if (NPCHealthLvl <= 0) {
            GameEventManager.post(new NPCStateEvent(2));
            Debug.Log("GAME OVER, YOU Will SUFFOCATE WITHOUT OXYGEN!!");
        }

        if (NPCHealthLvl > NPCMaxHealth) {
            NPCHealthLvl = NPCMaxHealth;
        }

        if (NPCHealthLvl < NPCMaxHealth/2)
        {
            //Debug.Log(" NPC HP: " + NPCHealthLvl.ToString());
            GameEventManager.post(new NPCStateEvent(2));
        }
        //Debug.Log(" NPC HP: " + NPCHealthLvl.ToString());
    }
    
}
