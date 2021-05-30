using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float Startspeed = 10f;

    public int enemyTypeNo;
    public static string enemyType;

    [HideInInspector]
    public float speed;

    public int startHealth = 100;
    private float health;

    public int moneyValue = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    public static int deathCount;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
        speed = Startspeed;
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.money += moneyValue;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        deathCount++;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Startspeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        if (enemyTypeNo == 1)
        {
            enemyType = "Light";
        }
        else if (enemyTypeNo == 2)
        {
            enemyType = "Medium";
        }
        else if (enemyTypeNo == 3)
        {
            enemyType = "Heavy";
        }
    }
    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        GameManager.Lives--;
        Destroy(gameObject);
    }
}
