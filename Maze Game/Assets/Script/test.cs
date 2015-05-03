using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Pathfinding;


public class test : MonoBehaviour
{
    TextAsset Jsontext;
    MapData Jsondata;
    Renderer rend;
    Camera camera;
    public GameObject player;
    public GameObject inside_wall;
    public GameObject outside_wall;
    public GameObject celling_cube;
    public GameObject plane;
    public GameObject portal;

    List<GameObject> walls;
    // Use this for initialization
    void Start()
    {
        walls = new List<GameObject>();
        Jsontext = Resources.Load<TextAsset>("jsondata2");

        Jsondata = JsonMapper.ToObject<MapData>(Jsontext.text);

        player = Instantiate(player, new Vector3(Jsondata.beginPoints[0].x + player.transform.localScale.x / 2f, 2, Jsondata.beginPoints[0].y + player.transform.localScale.z / 2f), Quaternion.Euler(new Vector3(0, Jsondata.beginPoints[0].angle))) as GameObject;
        GameObject cam = player.transform.Find("MainCamera").gameObject;
        camera = cam.GetComponent<Camera>() as Camera;

        foreach (Point v in Jsondata.endPoints)
        {
            Instantiate(portal, new Vector3(v.x * 4 - 2, 0.1f, v.y * 4 - 2), Quaternion.identity);
        }
        /*GameObject[] wall_objects = GameObject.FindGameObjectsWithTag("insidewall");
        foreach (GameObject v in wall_objects)
        {
            walls.Add(v);
        }*/


        GameObject g_walls = new GameObject("Walls");

        plane = Instantiate(plane, new Vector3(Jsondata.width * 2, 0, Jsondata.height * 2), Quaternion.identity) as GameObject;
        plane.transform.localScale = new Vector3(Jsondata.width * 0.4f, 1, Jsondata.height * 0.4f);
        plane.transform.parent = g_walls.transform;
        rend = plane.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width, Jsondata.height); // 바닥 타일 텍스쳐
        
        celling_cube = Instantiate(celling_cube, new Vector3(Jsondata.width * 4 / 2f, 4.5f, Jsondata.height * 4 / 2f), Quaternion.identity) as GameObject;
        celling_cube.transform.localScale = new Vector3(Jsondata.width * 4 + 2, 1, Jsondata.height * 4 + 2);
        celling_cube.transform.parent = g_walls.transform;
        rend = celling_cube.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width * 4, Jsondata.height * 4); // 천장 타일 텍스쳐

        foreach (NormalWall wall in Jsondata.objNormals)
        {
            GameObject temp = Instantiate(inside_wall, new Vector3(wall.x * 4 + inside_wall.transform.localScale.x / 2, 2, wall.y * 4 + inside_wall.transform.localScale.y / 2), Quaternion.identity) as GameObject;
            temp.transform.localScale = new Vector3(4, 4, 4);
            temp.transform.parent = g_walls.transform;
            walls.Add(temp);
        }

        createOusideWall(g_walls);
        PathFinding(Jsondata.width, Jsondata.height);
        //NavMeshBuilder.BuildNavMesh();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject v in walls)
        {
            if ((v.transform.position.x > player.transform.position.x - 30 &&
                v.transform.position.x < player.transform.position.x + 30 &&
                v.transform.position.z > player.transform.position.z - 30 &&
                v.transform.position.z < player.transform.position.z + 30) || // 플레이어 주위반경 30 모두 Mesh renderer ON
                (v.transform.position.z > 0
                && v.transform.position.z < Jsondata.width * 4
                && v.transform.position.x > player.transform.position.x - 6
                && v.transform.position.x < player.transform.position.x + 6) || // Z 축 모든 Mesh renderer ON
                (v.transform.position.x > 0
                && v.transform.position.x < Jsondata.width * 4
                && v.transform.position.z > player.transform.position.z - 6
                && v.transform.position.z < player.transform.position.z + 6)) // X 축 모든 Mesh renderer ON
            {
                v.GetComponent<MeshRenderer>().enabled = true;
            }
            /*else if (rayCasting(camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0))))
            {
                v.GetComponent<MeshRenderer>().enabled = true;
            }*/
            else
                v.GetComponent<MeshRenderer>().enabled = false;
        }

    }
    /*bool rayCasting(Ray ray)
    {
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj, 50))
        {
            GameObject obj = hitObj.transform.gameObject;
            obj.GetComponent<MeshRenderer>().enabled = true;
            return true;
        }
        return false;
    }*/
    void FixedUpdate()
    {
    }

    void createOusideWall(GameObject g_walls)
    {

        GameObject temp_wall;
        temp_wall = Instantiate(outside_wall, new Vector3(Jsondata.width * 4 / 2f, 2f, -0.5f), Quaternion.identity) as GameObject;
        temp_wall.transform.localScale = new Vector3(Jsondata.width * 4, 4, 1);
        temp_wall.transform.parent = g_walls.transform;
        rend = temp_wall.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width, 1); // 벽 타일 텍스쳐

        temp_wall = Instantiate(outside_wall, new Vector3(-0.5f, 2f, Jsondata.height * 4 / 2f), Quaternion.Euler(new Vector3(0, 90))) as GameObject;
        temp_wall.transform.localScale = new Vector3(Jsondata.height * 4, 4, 1);
        temp_wall.transform.parent = g_walls.transform;
        rend = temp_wall.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width, 1); // 벽 타일 텍스쳐

        temp_wall = Instantiate(outside_wall, new Vector3(Jsondata.width * 4 + 0.5f, 2f, Jsondata.height * 4 / 2f), Quaternion.Euler(new Vector3(0, 90))) as GameObject;
        temp_wall.transform.localScale = new Vector3(Jsondata.height * 4, 4, 1);
        temp_wall.transform.parent = g_walls.transform;
        rend = temp_wall.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width, 1); // 벽 타일 텍스쳐

        temp_wall = Instantiate(outside_wall, new Vector3(Jsondata.width * 4 / 2f, 2f, Jsondata.height * 4 + 0.5f), Quaternion.identity) as GameObject;
        temp_wall.transform.localScale = new Vector3(Jsondata.width * 4, 4, 1);
        temp_wall.transform.parent = g_walls.transform;
        rend = temp_wall.GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(Jsondata.width, 1); // 벽 타일 텍스쳐
    }
    void PathFinding(int width, int height)
    {
        AstarData data = AstarPath.active.astarData;
        GridGraph gg = data.AddGraph(typeof(GridGraph)) as GridGraph;
        gg.width = width * 4;
        gg.depth = height * 4;
        gg.nodeSize = 1;
        gg.center = new Vector3(Jsondata.width * 4 / 2f, 0, Jsondata.height * 4 / 2f);
        gg.UpdateSizeFromWidthDepth();
        gg.collision.mask = 1 << LayerMask.NameToLayer("Obstacles");
        gg.collision.heightMask = 1 << LayerMask.NameToLayer("Ground");
        
        AstarPath.active.Scan();
    }
}
