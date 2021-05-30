using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject OptionsPanel;
    bool active;
    private PanelManagerGame1 animationn;
    private string txt;   

    public void Start()
    {
        OptionsPanel.SetActive(false);
    }

    public void OpenandClose()
    {
        if (active == false)
        {
            OptionsPanel.transform.gameObject.SetActive(true);
            active = false;
        }
        else
        {
            OptionsPanel.transform.gameObject.SetActive(false);
            animationn.PopUpClose(txt);
            active = false;
        }
    }

}
