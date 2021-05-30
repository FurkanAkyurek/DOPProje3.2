using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int money = 0;
    public Text moneyText;
    public int startMoney = 250;

    public GameObject GameOverUI;
    public GameObject PrototipWinPanel;

    public static int Lives;
    public int startLives = 10;

    public static bool GameIsOver;

    public static int Rounds;

    public Animator ShopAnim,ChoosePanel;
    public static bool IsGameStart;

    public Button a, b, c;
    void Start()
    {
        money = startMoney;
        Lives = startLives;
        GameIsOver = false;
        IsGameStart = false;
        Rounds = 0;
    }

    void EndGame()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
    }

    void Update()
    {
        if (!IsGameStart)
        {
            ShopAnim.SetBool("Acik", false);
            ChoosePanel.SetBool("Acik", true);

            a.interactable = true;
            b.interactable = true;
            c.interactable = true;
        }
        else
        {
            ShopAnim.SetBool("Acik", true);
            ChoosePanel.SetBool("Acik", false);
        }

        if (WaveSpawner.waveIndex == Enemy.deathCount)
        {
            IsGameStart = false;
        }

        if (WaveSpawner.waveIndex == 3 && WaveSpawner.waveIndex == Enemy.deathCount)
        {
            PrototipWinPanel.SetActive(true);
        }

        moneyText.text = "Money = " + money.ToString();

        if (GameIsOver)
            return;

        if (Input.GetKeyDown("p"))
        {
            EndGame();
        }

        if (Lives <= 0)
        {
            EndGame();
        }
    }
    
}
