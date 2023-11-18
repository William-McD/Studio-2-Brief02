using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneAim : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemyList = new List<GameObject>();

    public float enemyDistance;
    public float nearestDistance = 1000f;

    public GameObject bullet;
    GameObject shootOrigin;
    public float shootTimer;
    public float shootTimerStart;

    private void Awake()
    {
        shootOrigin = transform.GetChild(0).gameObject;
        shootTimer = shootTimerStart;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        Vector2 direction = enemy.transform.position - transform.position;
        transform.up = direction;
        if (enemy != null)
        {
            ShootAtEnemy();
        }
    }

    void FindClosestEnemy()
    {
        if (enemy == null)
        {
            nearestDistance = 1000f;
            shootTimer = shootTimerStart;
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyDistance = Vector2.Distance(transform.position, enemyList[i].transform.position);
            if (enemyDistance < nearestDistance)
            {
                enemy = enemyList[i];
                nearestDistance = enemyDistance;
            }
        }
    }   
    void ShootAtEnemy()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Instantiate(bullet, shootOrigin.transform.position, shootOrigin.transform.rotation);
            shootTimer = shootTimerStart;
        }
    }
}
