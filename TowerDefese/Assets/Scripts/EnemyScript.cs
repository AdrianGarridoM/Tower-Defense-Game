using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float vel;
    private Transform target;
    private int WaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        vel = 10f;
        target = WaypointsScript.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * vel * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f){
            NextWaypoint();
        }

    }
    void NextWaypoint()
    {
        if(WaypointIndex >= WaypointsScript.points.Length){
            Destroy(gameObject);
            return;
        }
        WaypointIndex++;
        target = WaypointsScript.points[WaypointIndex];
    }
}
