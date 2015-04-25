using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private GameObject destination = null;

    private NavMeshAgent agent;

    void Start()
    {
        destination = GameObject.Find("Player(Clone)");

        agent = this.GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        if(destination == null) destination = GameObject.Find("Player(Clone)");
        agent.SetDestination(destination.transform.position);

        /*
        NavMeshPath path = new NavMeshPath();
        bool hasFoundPath = agent.CalculatePath(destination.transform.position, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            print("The agent can reach the destionation");
        }
        else if (path.status == NavMeshPathStatus.PathPartial)
        {
            print("The agent can only get close to the destination");
        }
        else if (path.status == NavMeshPathStatus.PathInvalid)
        {
            print("The agent cannot reach the destination");
            print("hasFoundPath will be false");
        }*/
    }
}