using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float peaceTime = 5f;
    private float countdown = 2f;
    private float actualWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(Wave());
            countdown = peaceTime;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator Wave()
    {
        actualWave++;
        for (int i=0; i<actualWave;i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
