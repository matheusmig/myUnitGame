﻿using UnityEngine;
using System.Collections;
using GameEvents;

//********************************************************************************
//  Realiza o ataque dos NPCs vegetais
//
//
//
//*********************************************************************************

public class NPCAtt : MonoBehaviour, GameEventListener {


    /////////////////////////////////////
    /// Variaveis de Ataque
    public float attackRange = 1f;
    public Transform targetPosition;
    public Transform mePosition;

    private float distToTarget;
    int NPCState;
    
    void Start() {
    }


    ///////////////////////////////////////////////////////////////////////////
    // EVENT LISTENING
    //////////////////////////////////////////////////////////////////////////

    public void eventReceived(GameEvent e)
    {
        if (e is NPCStateEvent)
        {
            NPCState = (e as NPCStateEvent).NPCState;
        }
    }

void Update()
        {
        switch (NPCState) {
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
    }


    ///////////////////////////////////////////////////////
    /// Métodos de AI de ataque do Vegetal como amigo
    void State2AI() {

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


