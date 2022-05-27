using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 15f;
    private Transform target;
    private int index = 0;
    private int health = 100;
    public int value;
    void Start()
    {
        target = WaypointsScript.points[index];    
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<= 0.3f)
        {
            NextWaypoint();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
    void NextWaypoint()
    {
        if(index>= WaypointsScript.points.Length-1)
        {
            EndReached();
            return;
        }

        index++;
        target = WaypointsScript.points[index];
    }
    void EndReached()
    {
        PlayerStats.UpdateLives(-1);
        Death();
    }
    void Death()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }
}
