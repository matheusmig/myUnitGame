using UnityEngine;
using System.Collections;

//********************************************************************************
// Controla a A.I. de um NPC
//
// Os métodos tem por característica retornar uma posição ou transform, a qual deverão
// ser aplicadas a um personagem.
//*********************************************************************************

public class NPCAI : MonoBehaviour {

	public Transform target; //the enemy's target
	public Transform me;	 //current transform data of this enemy
	public float range = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
		
		
		}

	
	}
}
