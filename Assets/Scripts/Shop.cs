using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint FireTower;
    public TurretBlueprint ElectricTower;
    public TurretBlueprint EarthTower;
    public TurretBlueprint IceTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectSFireTower()
    {
        buildManager.SelectTurretToBuild(FireTower);
    }

    public void SelectElectricTower()
    {
        buildManager.SelectTurretToBuild(ElectricTower);
    }
    public void SelectEarthTower()
    {
        buildManager.SelectTurretToBuild(EarthTower);
    }
    public void SelectIceTower()
    {
        buildManager.SelectTurretToBuild(IceTower);
    }
}
