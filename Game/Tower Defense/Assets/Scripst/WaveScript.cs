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
        MapBuilderScript.done = false;
        wave++;
        if(wave == 1 || wave == 6)
        {
            MapBuilderScript.done2 = true;
        }
        for (int i = 0; i <= wave; i++)
        {
            SpawnEnemy(enemyPrefab[0]);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        if (wave >= 3)
        {
            for(int i = 0; i <= wave / 2; i++)
            {
                SpawnEnemy(enemyPrefab[1]);
            }
        }
        if (wave >= 6)
        {
            for (int i = 0; i <= wave / 3; i++)
            {
                SpawnEnemy(enemyPrefab[2]);
                yield return new WaitForSeconds(0.5f);
                count++;
            }
        }
        if (wave % 10 == 0)
        {
            SpawnEnemy(enemyPrefab[3]);
            count++;
        }

    }
    private void Awake()
    {
        wave = 0;
        count = 0;
    }
    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position + new Vector3(0,2,0), enemy.rotation).parent = padre.transform;
    }


    public void StartWave()
    {
       StartCoroutine(SpawnWave());
    }
}
