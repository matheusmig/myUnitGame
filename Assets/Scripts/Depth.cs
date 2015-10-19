using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {

	private float XPosition;
	private float YPosition;


	void Update () {
		XPosition = transform.position.x;
		YPosition = transform.position.y;
		//A posiçao Z será baseada na altura (posiçao Y)
		transform.position = new Vector3 (XPosition, YPosition, YPosition);
	}
}
