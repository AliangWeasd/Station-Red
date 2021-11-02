using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : MonoBehaviour
{
    //private float elapsed = 0.0f;
    public float rotSpeed = 360f;
    public float speed = 5f;

    LineRenderer line;
    public Transform target;
    public NavMeshAgent agent;
    private NavMeshPath path;
    Rigidbody2D rb;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        line = GetComponent<LineRenderer>();
        NavMeshPath path = new NavMeshPath();
        rb = GetComponent<Rigidbody2D>();

        agent.SetDestination(target.position);
        yield return new WaitForEndOfFrame();

        DrawPath(agent.path);

        agent.updatePosition = false;
        /*
        elapsed = 0.0f;
        path = new NavMeshPath();

        DrawPath(path);
        */
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Force);
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
        //Debug.Log (x);

        Quaternion angle = Quaternion.Euler(0, 0, x);

        transform.rotation = Quaternion.Lerp(transform.rotation, angle, rotSpeed * Time.deltaTime);

        //rb.AddForce(transform.up * speed, ForceMode2D.Force);
        Debug.Log(transform.position);
        /*
        for (int i = 1; i < path.corners.Length;i++)
        {
            line.SetPosition(i, path.corners[i]);
            Debug.Log(path.corners[i]);
        }
        */
        /*
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        Debug.Log(path.corners[1]);
        */
    }
}
