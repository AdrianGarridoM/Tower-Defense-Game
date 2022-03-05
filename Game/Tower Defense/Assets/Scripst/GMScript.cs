using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    private float countDown=3;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform padre;
    private int wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = 2f + wave;
        }
        countDown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        for(int i =0; i <= wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        wave++;
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).parent = padre.transform;
    }
}
