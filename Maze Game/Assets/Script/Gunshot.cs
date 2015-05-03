using UnityEngine;
using System.Collections;

public class Gunshot : MonoBehaviour
{
    ParticleSystem[] muzzleParticles;
    public GameObject shotpoint;
    public GameObject muzzlepoint;
    public GameObject bullet;

    void Start()
    {
#if UNITY_ANDROID
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        this.transform.FindChild("MainCamera").GetComponent<UnityStandardAssets.Characters.FirstPerson.HeadBob>().enabled = false;
#endif
        GameObject muzzle = GameObject.Find("FX_Laser_Muzzle").transform.Find("Particles").gameObject;
        muzzleParticles = muzzle.transform.GetComponentsInChildren<ParticleSystem>();
        

	}

    void Update()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bullet, shotpoint.transform.position, Quaternion.FromToRotation(shotpoint.transform.localPosition, shotpoint.transform.parent.parent.transform.forward)) as GameObject;
            b.GetComponent<Rigidbody>().AddForce(shotpoint.transform.forward * 150f);

            foreach(ParticleSystem v in muzzleParticles)
            {
                v.Stop();
                v.Clear();
                v.Play();
            }
        }
         /*
        else if(Input.GetMouseButtonDown(1))
        {
            modeFlag = !modeFlag;


            GameObject gun = GameObject.Find("gun");
            switch (modeFlag)
            {
                case true:
                    gun.transform.position = Vector3.Lerp(gun.transform.position, gun.transform.position + new Vector3(-0.45f, 0, 0), 1f);
                    break;
                case false:
                    gun.transform.position = Vector3.Lerp(gun.transform.position, gun.transform.position + new Vector3(+0.45f, 0, 0), 1f);
                    break;
            }
        }*/
	}
}
