using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool bleed;
    public bool frost;
    public Transform Target;
    public float speed;
    public GameObject impact;
    public float explosion;
    public int damage;
    public void Chase(Transform target)
    {
        Target = target;
    }
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        float FrameDistance = speed * Time.deltaTime;
        if (dir.magnitude <= FrameDistance)
        {
            HitEnemy();
            return;
        }
        transform.Translate(dir.normalized * FrameDistance, Space.World);
        transform.LookAt(Target);
    }

    private void HitEnemy()
    {
        GameObject impactEffect = (GameObject)Instantiate(impact, transform.position, transform.rotation);
        Destroy(impactEffect, 1f);
        if (explosion > 0f)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosion);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }
        else
        {
            Damage(Target.transform);
        }
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        EnemyScript e = enemy.GetComponent<EnemyScript>();
        e.TakeDamage(damage);
        if (bleed)
        {
            e.BleedDamage(damage/4);
        }
        if (frost)
        {
            e.FrostDamage(damage/4);
        }
    }
    public void IncreaseDamage(int increase)
    {
        damage += increase;
    }
}
