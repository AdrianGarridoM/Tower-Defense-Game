using System.Collections;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private float countDown = 3;
    public Transform[] enemyPrefab;
    public Transform spawnPoint;
    public Transform padre;
    public static int wave = 0;
    private int waveLimit = 14;
    public static int count = 0;
    void Start()
    {

    }

    void Update()
    {
        if (count == 0)
        {
            if (countDown <= 0)
            {
                StartCoroutine(SpawnWave());
                countDown = 2f + wave;
            }
            countDown -= Time.deltaTime;
        }
    }
    IEnumerator SpawnWave()
    {

        for (int i = 0; i <= wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        wave++;

    }
    void SpawnEnemy()
    {
        if (wave == waveLimit)
        {
            Instantiate(enemyPrefab[3], spawnPoint.position, spawnPoint.rotation).parent = padre.transform;
        }
        Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation).parent = padre.transform;
    }
}
