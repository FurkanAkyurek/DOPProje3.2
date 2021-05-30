using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefabLight, enemyPrefabMedium, enemyPrefabHeavy;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public static int waveIndex = 0;

    int type = 0;

    public Text WaveCountdownText;

    public Button a, b, c;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        if (GameManager.IsGameStart)
        {
            countdown -= Time.deltaTime;
        }
        

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", countdown);

        
    }

    IEnumerator SpawnWave()
    {
        
        GameManager.Rounds++;
        Enemy.deathCount = 0;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }              
    }

    void SpawnEnemy()
    {
        if (type == 1)
        {
            Instantiate(enemyPrefabLight, spawnPoint.position, spawnPoint.rotation);
        }
        else if (type == 2)
        {
            Instantiate(enemyPrefabMedium, spawnPoint.position, spawnPoint.rotation);
        }
        else if (type == 3)
        {
            Instantiate(enemyPrefabHeavy, spawnPoint.position, spawnPoint.rotation);
        }
    }
    public void LightButton()
    {
        GameManager.IsGameStart = true;
        type = 1;
        waveIndex++;
        a.interactable = false;
        b.interactable = false;
        c.interactable = false;
    }
    public void MediumButton()
    {
        GameManager.IsGameStart = true;
        type = 2;
        waveIndex++;
        a.interactable = false;
        b.interactable = false;
        c.interactable = false;
    }
    public void HeavyButton()
    {
        type = 3;
        GameManager.IsGameStart = true;
        waveIndex++;
        a.interactable = false;
        b.interactable = false;
        c.interactable = false;
    }
}
