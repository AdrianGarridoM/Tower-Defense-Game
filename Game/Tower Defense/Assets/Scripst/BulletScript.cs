using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform Target;
    float speed = 70f;
    public GameObject impact;
    public void Chase(Transform target)
    {
        Target = target;
    }
    void Update()
    {
        if(Target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        float FrameDistance = speed * Time.deltaTime;
        if(dir.magnitude <= FrameDistance)
        {
            HitEnemy();
            return;
        }
        transform.Translate(dir.normalized * FrameDistance, Space.World);
    }

    private void HitEnemy()
    {
        GameObject impactEffect = (GameObject)Instantiate(impact, transform.position, transform.rotation);
        Destroy(impactEffect, 1f);
        Destroy(Target.gameObject);
        Destroy(gameObject);
    }
}