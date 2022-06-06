using System.Collections;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public Transform[] enemyPrefab;
    public Transform spawnPoint;
    public Transform padre;
    [HideInInspector]
    public static int wave = 0;
    public static int waveLimit = 5;
    public static int count = 0;
 
     IEnumerator SpawnWave()
    {
        //MapBuilderScript;
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


    public void StartWave()
    {
       StartCoroutine(SpawnWave());
    }
}
