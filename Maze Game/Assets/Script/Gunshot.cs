using UnityEngine;
using System.Collections;

public class Gunshot : MonoBehaviour {
    public GameObject shotpoint;
    public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            GameObject temp = (GameObject)Instantiate(bullet, shotpoint.transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(shotpoint.transform.forward * 300f);
        }
	}
}
