using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float baseSpeed;
    private float speed;
    private Transform target;
    private int index = 0;
    public float starthealth = 100f;
    private float health;
    public int value;
    public Image HealthBar;
    public Image BleedBar;
    public Image FrostBar;

    void Start()
    {
        health = starthealth;
        speed = baseSpeed;
        target = GMScript.waypoints[index];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            NextWaypoint();
        }
        speed = baseSpeed;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / starthealth;
        if (health <= 0)
        {
            Death();
        }
    }
    public void BleedDamage(float damage)
    {

    }
    public void FrostDamage(float damage)
    {

    }
    public void Slow(float slow)
    {
        speed = baseSpeed * slow;
    }
    void NextWaypoint()
    {
        if (index >= GMScript.waypoints.Count-1)
        {
            EndReached();
            return;
        }

        index++;
        target = GMScript.waypoints[index];
    }
    void EndReached()
    {
        PlayerStats.UpdateLives(-1);
        Destroy(gameObject);
        WaveScript.count--;
    }
    void Death()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
        WaveScript.count--;
    }
}
