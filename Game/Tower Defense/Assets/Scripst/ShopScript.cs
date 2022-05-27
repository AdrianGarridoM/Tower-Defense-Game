using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuilderScript builder;
    public TowerBlueprint turretBlueprint;
    public TowerBlueprint rocketBlueprint;
    public TowerBlueprint laserBlueprint;
    private void Start()
    {
        builder = BuilderScript.buildInstance;
    }
    public void SelectTurret()
    {
        builder.SelectTowerToBuild(turretBlueprint);
    }
    public void SelectRocketLauncher()
    {
        builder.SelectTowerToBuild(rocketBlueprint);
    }
    public void SelectLaserBeamer(){
        builder.SelectTowerToBuild(laserBlueprint);
    }
}
