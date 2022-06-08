using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{
    public GameObject UpgradesUI;
    public void Show()
    {
        UpgradesUI.SetActive(true);
    }

    public void Hide()
    {
        UpgradesUI.SetActive(false);
    }
    public void TowerBleed(GameObject button)
    {
        TurretScript.bleed = true;
        Destroy(button);
        Hide();
    }
    public void TowerFrost(GameObject button)
    {
        TurretScript.frost = true;
        Destroy(button);
        Hide();
    }
}
