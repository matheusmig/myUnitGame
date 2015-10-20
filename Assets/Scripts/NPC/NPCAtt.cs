using UnityEngine;
using System.Collections;

//********************************************************************************
//  Realiza o ataque dos NPCs vegetais
//
//
//
//*********************************************************************************

public class NPCAtt : MonoBehaviour {


    /////////////////////////////////////
    /// Variaveis de Ataque
    public float attackRange = 1f;
    public Transform targetPosition;
    public Transform mePosition;

    private float distToTarget;


    void Start() {
    }

    void Update()
        {
        Debug.Log(" entrou no update: ");
        distToTarget = distanceToTarget();
        if (distToTarget != -1)
        {
            if (distToTarget < attackRange)
            {
                Debug.Log(" Morreu: ");
            }
            else
            {
                Debug.Log(" Viveu: ");
            }
        }
        else
        {
            Debug.Log(" foi menos um: ");
        }
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


