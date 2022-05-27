using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    public static BuilderScript buildInstance;
    public GameObject buildEffect;
    private TowerBlueprint towerToBuild;
    private void Awake()
    {
        if (buildInstance != null)
        {
            Debug.LogError("Why is there another builder?");
            return;
        }
        buildInstance = this;
    }
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public void BuildTowerOn(GroundScript ground)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            return;
        }
        PlayerStats.Money -= towerToBuild.cost;
        towerToBuild.cost += towerToBuild.addedCost;
        towerToBuild.displayCost.text = towerToBuild.cost.ToString();
        GameObject towerCheck = towerToBuild.tower;
        if (towerCheck.tag == "Turret")
        {
            GameObject tower = (GameObject)Instantiate(towerToBuild.tower, ground.transform.position + ground.offset, Quaternion.identity);
            ground.turret = tower;
        }
        else
        {
            GameObject tower = (GameObject)Instantiate(towerToBuild.tower, ground.transform.position, Quaternion.identity);
            ground.turret = tower;
        }
        GameObject effect = (GameObject)Instantiate(buildEffect, ground.transform.position, Quaternion.identity);
        Destroy(effect, 4f);
    }
}
