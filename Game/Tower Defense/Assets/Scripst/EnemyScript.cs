using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float baseSpeed = 15f;
    private float speed;
    private Transform target;
    private int index = 0;
    public float health = 100;
    public int value;

    void Start()
    {
        speed = baseSpeed;
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
        speed = baseSpeed;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
    public void Slow(float slow)
    {
        speed = baseSpeed * slow;
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
