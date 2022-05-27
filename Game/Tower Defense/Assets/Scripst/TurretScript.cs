using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
   
    public Transform Head;
    private Transform target;
    private EnemyScript targetEnemy;
    private float fireCount = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float range = 20f;
    private float turnSpeed = 20f;
    public float fireRate = 1f;

    [Header("Laser")]
    private int dot = 20;
    public bool useLaser = false;
    public LineRenderer Laser;
    public ParticleSystem LaserImpact;
    public ParticleSystem Glow;
    public Light light;
    private float slow = 0.5f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            if (Laser.enabled)
            {
                Laser.enabled = false;
                light.enabled = false;
                LaserImpact.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                Glow.Pause();
            }
            return;
        }
        else
        {
            LockOnTarget();
            if (useLaser)
            {
                LaserBeam();
            }
            else
            {
                if (fireCount <= 0f)
                {
                    Shoot();
                    fireCount = 1f / fireRate;
                }
                fireCount -= Time.deltaTime;
            }

        }
    }

    private void LaserBeam()
    {
        targetEnemy.TakeDamage(dot * Time.deltaTime);
        targetEnemy.Slow(slow);
        if (!Laser.enabled)
        {
            Laser.enabled = true;
            light.enabled = true;
            LaserImpact.Play();
            Glow.Play();
        }
        Laser.SetPosition(0, firePoint.position);
        Laser.SetPosition(1, target.position);
        Vector3 dir = firePoint.position - target.position;
        LaserImpact.transform.position = target.position + dir.normalized * 0.5f;
        LaserImpact.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void LockOnTarget()
    {
        //Turn head to closest enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Head.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject BulletObject = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = BulletObject.GetComponent<BulletScript>();
        if(bullet != null)
        {
            bullet.Chase(target);
        }
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
            targetEnemy = target.GetComponent<EnemyScript>();
        }
        else
        {
            target = null;
            targetEnemy = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
