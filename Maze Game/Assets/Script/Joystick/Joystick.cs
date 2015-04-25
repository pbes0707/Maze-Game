using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Joystick : MonoBehaviour {

	public GameObject joystick_thumb;

	GameObject PlayerObj;

	public float movementValue;
	public float maxSpeed;

	private Vector3 touchPos;
	private Vector3 moveVector;



	void OnDestroy(){
		//stop Player When joystick destroy
		PlayerObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
		if (PlayerObj == null) {
			PlayerObj = GameObject.Find("Player(Clone)");
		}
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (PlayerObj == null)
            PlayerObj = GameObject.Find("Player(Clone)");
		JoystickContol ();
	}

	void FixedUpdate()
	{
		if(PlayerObj.GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
		{
			PlayerObj.GetComponent<Rigidbody> ().velocity = PlayerObj.GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
		}
	}
	
	void JoystickContol()
	{
		
		for (int i=0; i<Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				//if(Input.GetTouch(i).position.x < Screen.width/2){
					Destroy (this.gameObject);
				//}
			}
			touchPos = (Input.GetTouch (i).position - (Vector2)this.transform.position);
			if(touchPos.x < Screen.width / 2){
				joystick_thumb.transform.localPosition = touchPos;
				moveVector = new Vector3 (joystick_thumb.transform.localPosition.x, PlayerObj.transform.localPosition.y, joystick_thumb.transform.localPosition.y) * movementValue;
				PlayerObj.GetComponent<Rigidbody> ().AddRelativeForce (moveVector);
			}
		}

	
	}
}
