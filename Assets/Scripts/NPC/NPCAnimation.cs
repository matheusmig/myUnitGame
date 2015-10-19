using UnityEngine;
using System.Collections;

public class NPCAnimation : MonoBehaviour {

	private bool        m_isFacingLeft;
	private Animator    m_anim;
	private Rigidbody2D m_rigid2d;

	void Start () {
		m_isFacingLeft = false;
		m_anim    = GetComponent<Animator> ();
		m_rigid2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_rigid2d.velocity.x > 0) {
			Flip("right");
			m_anim.SetBool("WalkRight",true);
			m_anim.SetBool("WalkLeft", false);
			m_anim.SetBool("Idle",     false);
		}
		if (m_rigid2d.velocity.x < 0) {
			Flip("left");
			m_anim.SetBool("WalkRight",false);
			m_anim.SetBool("WalkLeft", true);
			m_anim.SetBool("Idle",     false);
		}
		if (m_rigid2d.velocity.x == 0) {
			m_anim.SetBool("WalkRight",false);
			m_anim.SetBool("WalkLeft", false);
			m_anim.SetBool("Idle",     true);
		}
	
	}

	protected void Flip(string side)    
	{	
		if (side == "left" && !m_isFacingLeft) {
			//Debug.Log ("virou pra esquerda");
			m_isFacingLeft = true;
			m_anim.transform.localScale = new Vector3(-1, 1, 1);
		} else if (side == "right" && m_isFacingLeft) {
			//Debug.Log ("virou pra direita");
			m_isFacingLeft = false;
			m_anim.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
