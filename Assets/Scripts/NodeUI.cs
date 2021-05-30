using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject UI;
    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        UI.SetActive(true);

        sellAmount.text = "SELL \n " + target.turretBlueprint.GetSellAmount() + " Gold";
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }
}
