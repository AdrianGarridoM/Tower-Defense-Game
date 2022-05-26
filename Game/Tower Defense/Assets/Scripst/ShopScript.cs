using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuilderScript builder;
    private void Start()
    {
        builder = BuilderScript.buildInstance;
    }
    public void PurchaseTurret()
    {
        Debug.Log("Turret Purchased");
        builder.SetTowerToBuild(builder.turret);
    }
}
