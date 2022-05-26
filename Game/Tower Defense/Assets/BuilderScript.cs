using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static BuilderScript buildInstance;
    public GameObject turret;
    private GameObject towerToBuild;
    private void Awake()
    {
        if (buildInstance != null)
        {
            Debug.LogError("Why is there another builder?");
            return;
        }
        buildInstance = this;
    }
    private void Start()
    {
        towerToBuild = turret;
    }
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
