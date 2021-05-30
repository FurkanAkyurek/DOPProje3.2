using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 offset;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public GameObject turret;
    
    
    private Renderer rend;
    private Color startColor;

    BuildManager buildManagerr;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManagerr = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;      

        if (turret != null)
        {
            buildManagerr.SelectNode(this);
            return;
        }

        if (!buildManagerr.CanBuild)
            return;
        BuildTurret(buildManagerr.GetTurretToBuild());
        //buildManagerr.BuildTurretOn(this);
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (GameManager.money < blueprint.cost)
        {
            return;
        }
        GameManager.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManagerr.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void SellTower()
    {
        GameManager.money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManagerr.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())        
            return;
        
        if (!buildManagerr.CanBuild)
            return;

        if (buildManagerr.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
