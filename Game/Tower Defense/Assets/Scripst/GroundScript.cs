using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private GameObject turret;
    private Renderer rend;
    private Color initColor;
    public Color hoverColor;
    void Start()
    {
        rend = GetComponent<Renderer>();
        initColor = rend.material.color;
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = initColor;
    }
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("There is already a tower here");
        }
        else
        {
            GameObject towerToBuild = BuilderScript.buildInstance.GetTowerToBuild();
            turret = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
        }

    }
}
