using UnityEngine;
using System.Collections;

public class DamagePopUp : MonoBehaviour {
	private Vector3 position;
	private Vector3 screenPointPosition;
	private Camera cameraHold;
	private string  text;

	// Use this for initialization
	void Start () {
		cameraHold = Camera.main;
		position.y = -position.y; //posiçao de y e inversa 
		screenPointPosition = cameraHold.WorldToScreenPoint (position);
	}
	
	// Update is called once per frame
	void Update () {
		screenPointPosition.y -= 1;
	}

	public static void ShowMessage(string texto, Vector3 positionRcvd){
		Debug.Log (positionRcvd);
		var newInst  = new GameObject("Damage Popup");
		var dmgPopUp = newInst.AddComponent<DamagePopUp> ();
		dmgPopUp.position = positionRcvd;
		dmgPopUp.text = texto;
	}

	void OnGUI(){
		//Debug.Log (screenPointPosition);
		var screenPX = cameraHold.WorldToScreenPoint (position);  
		GUI.Label (new Rect (screenPX.x, screenPointPosition.y, 150, 20), text);
		Destroy (gameObject, 1); 
	}
}
