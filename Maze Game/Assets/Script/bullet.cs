using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject particle;
    void FixedUpdate()
    {
        if(transform.position.y<0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
