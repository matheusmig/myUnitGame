using UnityEngine;
using System.Collections;

//********************************************************************************
// Gerencia (criando e destruindo) todos requisitos de um NPC
//
// Contém:
// Movimentação
// Animação
//
//*********************************************************************************
[RequireComponent (typeof (Rigidbody))] //requer que um rigidbody seja instanciado

public class NPCDaemon : MonoBehaviour {

	public Animator m_anim;		 //Classe que gerencia a animação
	private Rigidbody2D m_rigid;	 //Classe que armazena o rigidBody do NPC 

	public Transform m_target;     //Alvo atual do inimigo
	public Transform m_me;	 	 //Matriz de transformacao atual do NPC


	//////////////////////////////////////
	/// Variaveis de Movimentação
	public  float   m_speed;
	public  float   m_range = 1f; 
	private Vector2 m_actualDirection;
	private bool    m_stun;
	private float   m_stuntime;
	private float   m_distanceToTarget;

	//////////////////////////////////////
	/// Variaveis de IA
	private int m_wallLayer;

	//////////////////////////////////////
	/// Variaveis de Animação
	private bool m_isFacingLeft;  


    void Awake(){
		m_me = transform; //cache transform data for easy access/performance
	}

	// Use this for initialization
	void Start () {
		m_wallLayer = 1 << 8; //binary operation
		m_isFacingLeft = false;
		m_stuntime = 0;
		m_stun = false;
		m_rigid = GetComponent<Rigidbody2D>();
		directionToTarget();
	}
	
	// Update is called once per frame
	void Update () {
        m_distanceToTarget = distanceToTarget();
		m_actualDirection = directionToTarget();

		if (m_stuntime > 0) {
			m_stuntime -= Time.deltaTime;
		} else {
			m_stun = false;
		}

		if (!m_stun) {
			if (m_target){
				if((m_distanceToTarget < m_range) && !isPathObstructed()) {
					Move(m_actualDirection, m_speed);
				} else {
					Move(new Vector3 (1, 0, 0), m_speed);
				}
			} else {
				Move(new Vector3 (1, 0, 0), m_speed);
			}
		}


	}

	//////////////////////////////////////
	/// Métodos de Movimentação
	public void Move(Vector3 direction, float speed){
		m_rigid.AddForce(direction * speed);
	}

	void OnCollisionEnter2D(Collision2D playerhit){
		//Debug.Log (playerhit.gameObject.tag);
		if (playerhit.gameObject.tag == "Player") {
			Debug.Log ("Chocou-se");
			m_stun = true;
			m_stuntime = 2;
		}
	}

	//////////////////////////////////////
	/// Métodos de I.A.
	public Vector2 directionToTarget(){
		float xDiff, yDiff;
		xDiff = m_target.position.x - m_me.position.x;
		yDiff = m_target.position.y - m_me.position.y;
		m_actualDirection = new Vector2(xDiff, yDiff).normalized;
		return m_actualDirection.normalized;
	}

	public float distanceToTarget(){
		if (m_target) {
			return Vector3.Distance (m_me.position, m_target.position);
		} else {
			return -1;
		}
	}

	public bool isPathObstructed(){
		if (Physics2D.Raycast( m_me.position, m_actualDirection, 2, m_wallLayer)){
			Debug.DrawLine(m_me.position, new Vector3(m_actualDirection.x,m_actualDirection.y,0), Color.red); 
			return true;
		} else {
			Debug.DrawRay (m_me.position, m_actualDirection, Color.yellow);
			return false;
		}
	}


	//////////////////////////////////////
	/// Métodos de Animação


}
