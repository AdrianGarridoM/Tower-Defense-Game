using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public Vector3 offset;
    private GameObject turret;
    private Renderer rend;
    private Color initColor;
    public Color hoverColor;
    BuilderScript builder;
    void Start()
    {
        rend = GetComponent<Renderer>();
        initColor = rend.material.color;
        builder = BuilderScript.buildInstance;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (builder.GetTowerToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = initColor;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (builder.GetTowerToBuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            //Inspect & Upgrade
            Debug.Log("There is already a tower here");
        }
        else
        {
            GameObject towerToBuild = builder.GetTowerToBuild();
            if(towerToBuild.tag == "Turret")
            {
                turret = (GameObject)Instantiate(towerToBuild, transform.position + offset, transform.rotation);
            }
            
        }

    }
}
