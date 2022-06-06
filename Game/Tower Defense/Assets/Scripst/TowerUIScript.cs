using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    private GroundScript ground;
    public Text upgradeText;
    public Text sellText;
    private void Start()
    {
        Hide();
    }
    private void Update()
    {
        upgradeText.text = (ground.turret.GetComponent<TurretScript>().level * ground.GetBlueprint().upgradeCost).ToString();
    }
    public void SetGround(GroundScript _ground)
    {
        gameObject.SetActive(true);
        enabled = true;
        ground = _ground;
        transform.position = ground.transform.position;
        upgradeText.text = (ground.turret.GetComponent<TurretScript>().level * ground.GetBlueprint().upgradeCost).ToString();
        sellText.text = (ground.GetBlueprint().cost - ground.GetBlueprint().addedCost).ToString();
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

}
