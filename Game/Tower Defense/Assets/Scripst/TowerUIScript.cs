using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    private GroundScript ground;
    public Text upgrade;
    public Text sell;
    public Text bleed;
    public Text frost;
    public Text range;
    public Text dmg;
    public Text rate;
    private void Start()
    {
        Hide();
    }
    private void Update()
    {
        upgrade.text = (ground.turret.GetComponent<TurretScript>().level * ground.GetBlueprint().upgradeCost).ToString();
    }
    public void SetGround(GroundScript _ground)
    {
        gameObject.SetActive(true);
        enabled = true;
        ground = _ground;
        transform.position = ground.transform.position;
        upgrade.text = (ground.turret.GetComponent<TurretScript>().level * ground.GetBlueprint().upgradeCost).ToString();
        sell.text = (ground.GetBlueprint().cost - ground.GetBlueprint().addedCost).ToString();
        Stats();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Upgrade()
    {
        ground.Upgrade();
    }


    public void Sell()
    {
        ground.Sell();
        Hide();
    }
    public void Stats()
    {
        range.text = "Range: "+ground.turret.GetComponent<TurretScript>().range.ToString();
        dmg.text = "Damage: "+ground.turret.GetComponent<TurretScript>().bulletPrefab.GetComponent<BulletScript>().damage.ToString();
        rate.text = "FireRate: "+ground.turret.GetComponent<TurretScript>().fireRate.ToString()+" RPS";
        bool _bleed = TurretScript.bleed;
        bool _frost = TurretScript.frost;
        if (_bleed) bleed.text = "25 %";
        if (_frost) frost.text = "25 %";
    }

}
