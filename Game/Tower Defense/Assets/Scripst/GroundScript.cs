using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public Vector3 offset;
    public GameObject turret;
    private Renderer rend;
    private Color initColor;
    public Color hoverColor;
    public Color noMoneyColor;
    BuilderScript builder;
    void Start()
    {
        rend = GetComponent<Renderer>();
        initColor = rend.material.color;
        builder = BuilderScript.buildInstance;
        noMoneyColor = Color.red;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!builder.CanBuild)
        {
            return;
        }
        if (builder.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
        
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
        if (!builder.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            //Inspect & Upgrade
            Debug.Log("There is already a tower here");
            return;
        }
        builder.BuildTowerOn(this);

    }
}
