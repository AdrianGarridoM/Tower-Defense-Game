using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 10f;
    private Transform target;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = WaypointsScript.points[index];    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<= 0.3f)
        {
            NextWaypoint();
        }
    }
    void NextWaypoint()
    {
        if(index>= WaypointsScript.points.Length)
        {
            Destroy(gameObject);
            return;
        }
        index++;
        target = WaypointsScript.points[index];
    }
}
