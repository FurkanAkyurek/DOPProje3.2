using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManagerGame1 : MonoBehaviour
{
    public GameObject PopUpBox;
    public Animator animator;
    public string popUp;
    public bool isopen;

    public void Start()
    {
        PopUpBox.SetActive(false);
    }

    public void PopUpOpen(string text)
    {
        PopUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }

    public void PopUpClose(string text)
    {
        animator.SetTrigger("close");
    }

    public void ButtonPressed()
    {
        if (isopen == false)
        {
            PopUpOpen(popUp);
            isopen = true;
        }
        else
        {
            PopUpClose(popUp);
            isopen = false;
        }
    }
}