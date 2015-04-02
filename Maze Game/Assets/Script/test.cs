using UnityEngine;
using System.Collections;
using LitJson;


public class test : MonoBehaviour {
    TextAsset Jsontext;
    MazeData Jsondata;
    GameObject Player;
    public GameObject cube;
	// Use this for initialization
	void Start () {
        Player = Resources.Load<GameObject>("Player");
        Jsontext = Resources.Load<TextAsset>("Jsondata");

        Jsondata = JsonMapper.ToObject<MazeData>(Jsontext.text);

        GameObject.Find("Plane").transform.localScale = new Vector3(Jsondata.width * 0.1f, 1, Jsondata.height * 0.1f);
        GameObject.Find("Plane").transform.position =  new Vector3(Jsondata.width /2f, 0, Jsondata.height /2f);

        Instantiate(Player, new Vector3(Jsondata.beginPoints[0].x + Player.transform.localScale.x / 2f, 0.8f, Jsondata.beginPoints[0].y + Player.transform.localScale.z / 2f), Quaternion.Euler(new Vector3(0, Jsondata.beginPoints[0].angle)));

        foreach(mapData map in Jsondata.mapDatas)
        {
            switch(map.type)
            {
                case "normal":
                    {
                        GameObject temp = Instantiate(cube, new Vector3(map.x + map.width / 2f, 2, map.y + map.height / 2f), Quaternion.identity) as GameObject;
                        temp.transform.localScale = new Vector3(map.width, 4, map.height);
                        
                        break;
                    }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
