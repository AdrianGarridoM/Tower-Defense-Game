using System.Collections;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public Transform[] enemyPrefab;
    public Transform spawnPoint;
    public Transform padre;
    [HideInInspector]
    public static int wave;
    public static int waveLimit = 10;
    public static int count;
 
   
     IEnumerator SpawnWave()
    {
        wave++;
        for (int i = 0; i <= wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        

    }
    private void Awake()
    {
        wave = 0;
        count = 0;
    }
    void SpawnEnemy()
    {
        if (wave == waveLimit)
        {
            Instantiate(enemyPrefab[3], spawnPoint.position + new Vector3(0, 2, 0), enemyPrefab[3].rotation).parent = padre.transform;
        }
        Instantiate(enemyPrefab[0], spawnPoint.position + new Vector3(0,2,0), enemyPrefab[0].rotation).parent = padre.transform;
    }


    public void StartWave()
    {
       StartCoroutine(SpawnWave());
    }
}
