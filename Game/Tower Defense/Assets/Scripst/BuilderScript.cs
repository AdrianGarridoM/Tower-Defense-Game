using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
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
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
