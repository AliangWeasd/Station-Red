using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolBehavior : MonoBehaviour
{
    public float rotSpeed = 360f;
    public float speed = 5f;

    LineRenderer line;
    public NavMeshAgent agent;
    public Vector3[] patrolNodes;
    private int currentNode = 0;
    private NavMeshPath path;
    Rigidbody2D rb;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        line = GetComponent<LineRenderer>();
        NavMeshPath path = new NavMeshPath();
        rb = GetComponent<Rigidbody2D>();

        agent.SetDestination(patrolNodes[currentNode]);
        yield return new WaitForEndOfFrame();

        DrawPath(agent.path);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 2)
        {
            currentNode = (currentNode + 1) % patrolNodes.Length;
            agent.SetDestination(patrolNodes[currentNode]);
        }
    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return;

        line.positionCount = path.corners.Length;

        Vector3 direction = path.corners[1] - transform.position;

        float x = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        if (x < 0)
            x = 360 + x;

        Quaternion angle = Quaternion.Euler(0, 0, x);

        transform.rotation = Quaternion.Lerp(transform.rotation, angle, rotSpeed * Time.deltaTime);

        //Debug.Log(transform.position);
    }
}