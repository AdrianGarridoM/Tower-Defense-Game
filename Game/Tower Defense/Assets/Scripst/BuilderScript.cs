using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    public static BuilderScript buildInstance;
    public GameObject buildEffect;
    public TowerUIScript towerUI;
    private TowerBlueprint towerToBuild;
    private GroundScript groundSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            towerUI.Hide();
            towerToBuild = null;
            groundSelected = null;
            return;
        }
    }
    private void Awake()
    {
        if (buildInstance != null)
        {
            Debug.LogError("Why is there another builder?");
            return;
        }
        buildInstance = this;
    }
    public void SelectGround(GroundScript ground)
    {
        groundSelected = ground;
        towerUI.SetGround(ground);
        towerToBuild = null;
    }
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        groundSelected = null;
    }
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public TowerBlueprint GetBlueprint()
    {
        return towerToBuild;
    }
}
