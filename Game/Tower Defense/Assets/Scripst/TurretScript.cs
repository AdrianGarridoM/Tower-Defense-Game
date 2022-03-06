using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform Head;
    private Transform target;
    private float range = 15f;
    private float turnSpeed = 10f;
    private float fireRate = 1f;
    private float fireCount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        else
        {
            //Turn head to closest enemy
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(Head.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            Head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            if (fireCount <= 0f)
            {
                Shoot();
                fireCount = 1f / fireRate;
            }
            fireCount -= Time.deltaTime;
        }
    }
    void Shoot()
    {

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortDistance > dist)
            {
                shortDistance = dist;
                nearestEnemy = enemy;
            }

        }
        if(nearestEnemy !=null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
