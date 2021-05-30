using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void ButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonPressedDeneme()
    {
        SceneManager.LoadScene("MusicDeneme");
    }
}
