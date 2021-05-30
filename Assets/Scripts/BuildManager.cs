using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Birden fazla BuildManager koydun");
            return;
        }
        instance = this;
    }

    public GameObject FireTowerPrefab;
    public GameObject ElectricTowerPrefab;
    public GameObject EarthTowerPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeui;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public bool HasMoney
    {
        get { return GameManager.money >= turretToBuild.cost; }
    }

    public void BuildTurretOn(Node node)
    {

        if (GameManager.money < turretToBuild.cost)
        {
            Debug.Log("Yeteri kadar paran yok");
            return;
        }

        GameManager.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build. Money left: " + GameManager.money);
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turretToBuild = null;

        nodeui.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeui.Hide();
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}