using UnityEngine;
using UnityEngine.EventSystems;

public class GroundScript : MonoBehaviour
{
    public Vector3 offset;
    public GameObject turret;
    private Renderer rend;
    private Color initColor;
    public Color hoverColor;
    public Color noMoneyColor;
    BuilderScript builder;
    public GameObject buildEffect;
    private TowerBlueprint blueprint;
    
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
        if (builder == null)
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
        if (builder == null)
        {
            return;
        }
        if (turret != null)
        {
            //Inspect & Upgrade
            builder.SelectGround(this);
            return;
        }
        if (!builder.CanBuild)
        {
            return;
        }
        BuildTower(builder.GetBlueprint());

    }
    public void BuildTower(TowerBlueprint _blueprint)
    {
        if (PlayerStats.Money < _blueprint.cost)
        {
            return;
        }
        blueprint = _blueprint;
        PlayerStats.Money -= _blueprint.cost;
        _blueprint.cost += _blueprint.addedCost;
        _blueprint.displayCost.text = _blueprint.cost.ToString();
        GameObject towerCheck = _blueprint.tower;
        if (towerCheck.tag == "Turret")
        {
            GameObject tower = (GameObject)Instantiate(_blueprint.tower, transform.position + offset, Quaternion.identity);
            turret = tower;
        }
        else
        {
            GameObject tower = (GameObject)Instantiate(_blueprint.tower, transform.position, Quaternion.identity);
            turret = tower;
        }
        GameObject effect = (GameObject)Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
    }

    public void Upgrade()
    {
        int upgradeCost = blueprint.upgradeCost * turret.GetComponent<TurretScript>().level;
        if (PlayerStats.Money < upgradeCost) return;

        turret.GetComponent<TurretScript>().IncreaseDamage(1);
        PlayerStats.Money -= upgradeCost;
        turret.GetComponent<TurretScript>().level++;
        GameObject effect = (GameObject)Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
    }
    public void Sell()
    {
        Destroy(turret.gameObject);
        blueprint.cost = blueprint.cost - blueprint.addedCost;
        PlayerStats.Money += blueprint.cost;
        blueprint.displayCost.text = blueprint.cost.ToString();
    }

    public TowerBlueprint GetBlueprint()
    {
        return blueprint;
    }

   
}
