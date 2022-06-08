using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float bleedLimit;
    private float frostLimit;
    private float bleed;
    private float frost;
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
        bleed = 0;
        frost = 0;
        bleedLimit = 50;
        frostLimit = 50;
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
        if (speed < baseSpeed)
        {
            speed += 2 * Time.deltaTime;
        }
        if (bleed > 0)
        {
            bleed -= 1 * Time.deltaTime;
        }
        if (frost > 0)
        {
            frost -= 1 * Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / starthealth;
        if (health <= 0)
        {
            PlayerStats.Money += value;
            Death();
        }
    }
    public void BleedDamage(float damage)
    {
        bleed += damage;
        BleedBar.fillAmount = bleed/bleedLimit;
        if(bleed >= bleedLimit)
        {
            TakeDamage(starthealth / 2);
            bleed = 0;
            bleedLimit += 10;
        }
    }
    public void FrostDamage(float damage)
    {
        frost += damage;
        FrostBar.fillAmount = frost / frostLimit;
        Slow(0.1f);
        if (frost >= frostLimit)
        {
            TakeDamage(starthealth / 3);
            frost = 0;
            frostLimit += 10;
        }
    }
    public void Slow(float slow)
    {
        Mathf.Clamp(speed, 8, 60);
        speed -= speed * slow;
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
        Death();
        
    }
    void Death()
    {
        Destroy(gameObject);
        WaveScript.count--;
        if(WaveScript.count == 0)
        {
            MapBuilderScript.done = true;
        }
    }
}
