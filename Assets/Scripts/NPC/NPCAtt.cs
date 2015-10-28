using UnityEngine;
using System.Collections;
using GameEvents;

//********************************************************************************
//  Realiza o ataque dos NPCs vegetais
//
//
//
//*********************************************************************************
//[RequireComponent(typeof(Rigidbody))] //requer que um rigidbody seja instanciado
public class NPCAtt : MonoBehaviour, GameEventListener {


    /////////////////////////////////////
    /// Variaveis de Ataque
    public float attackRange = 1f;
    private Transform targetPosition;
    public Transform mePosition;

    private float distToTarget;
    public ParticleSystem particle;

    void Start() {
		targetPosition = GameObject.FindWithTag("Player").transform;
    }


    ///////////////////////////////////////////////////////////////////////////
    // EVENT LISTENING
    //////////////////////////////////////////////////////////////////////////

    public void eventReceived(GameEvent e)
    {
        if (e is NPCStateEvent)
        {
            //NPCDaemon.NPCStateAtt = (e as NPCStateEvent).NPCState;
        }
    }

void Update()
        {
       // Debug.Log("State: " + NPCDaemon.NPCStateS);
		switch (NPCDaemon.actualState) {
            case 1:
                State1AI();
                break;
            case 2:
                State2AI();
                break;
        }       
    }



    ///////////////////////////////////////////////////////
    /// Métodos de AI de Ataque do Vegetal como Inimigo
    void State1AI() {
        distToTarget = distanceToTarget();
        if (distToTarget != -1) {
            if (distToTarget < attackRange) {
                //Debug.Log(" Morreu: ");
                GameEventManager.post(new PlayerHealthEvent(-1));
            }
            else {
                //Debug.Log(" Viveu: ");
                //GameEventManager.post(new PlayerHealthEvent(0));
            }
        }
        else {
            Debug.Log(" foi menos um: ");
        }

        // activate the particle
        particle.Play();
        //particle.Stop();
    }


    ///////////////////////////////////////////////////////
    /// Métodos de AI de ataque do Vegetal como amigo
    void State2AI() {
        particle.Stop();
    }

    public float distanceToTarget()
    {
        if (targetPosition) {
            return Vector3.Distance(mePosition.position, targetPosition.position);
        }
        else {
            return -1;
        }
    }
}


