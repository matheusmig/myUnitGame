using UnityEngine;
using System.Collections;

//********************************************************************************
// Faz a movimentação de um objeto no cenário, através de um RigidBody2d
//
//
//
//*********************************************************************************

public class NPCMovement {

	private Rigidbody2D m_rigid;

	public NPCMovement (Rigidbody2D rigid){
		m_rigid = rigid;
	}

	public void move(Vector3 direction, float speed){
		m_rigid.AddForce(direction * speed);
	}


}
