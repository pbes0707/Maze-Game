using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour {

	public float cameraContolValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i=0; i<Input.touchCount; i++) {
            if(Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                Vector3 touchPos = Input.GetTouch(i).position;
                if (touchPos.x > Screen.width / 2)
                {
                    this.transform.localEulerAngles =
                        new Vector3((this.transform.localEulerAngles.x - Input.GetTouch(i).deltaPosition.y * cameraContolValue), (this.transform.localEulerAngles.y + Input.GetTouch(i).deltaPosition.x * cameraContolValue), 0f);

                }
            }
		}
	
	}
}
