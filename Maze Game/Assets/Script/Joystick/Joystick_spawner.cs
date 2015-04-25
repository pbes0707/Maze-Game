using UnityEngine;
using System.Collections;

public class Joystick_spawner : MonoBehaviour {

	public GameObject joystick;

	private Vector3 touchPos;


	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {

		for (int i=0; i<Input.touchCount; i++) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				touchPos = Input.GetTouch(i).position;

				GameObject temp;
				if (touchPos.x < Screen.width / 2) {
					temp = Instantiate (joystick, touchPos, this.transform.rotation) as GameObject;
					temp.transform.parent = this.transform;
					temp.transform.localScale = Vector3.one;
					//instantiate joystick -> child of canvas
				}

			}
		}
		
	}
}
