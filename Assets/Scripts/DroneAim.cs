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


    //connors stuff
    public GameObject droneAnimation;
    public float animTimer;
    public bool droneShooting;
    //connors stuff


    private void Awake()
    {
        shootOrigin = transform.GetChild(0).gameObject;
        shootTimer = shootTimerStart;
        animTimer = .3f;

    }

    // Update is called once per frame
    void Update()
    {
        droneAnimation.GetComponent<Animator>().SetBool("droneShooting", droneShooting);

        FindClosestEnemy();
        Vector2 direction = enemy.transform.position - transform.position;
        transform.up = direction;

        if (enemy != null)
        {
            ShootAtEnemy();

            //connors stuff
            if (animTimer > 0 && droneShooting == true)
            {
                animTimer -= Time.deltaTime;
                if (animTimer <= 0)
                {
                    droneShooting = false;
                    animTimer = 0.3f;
                }
            }
            //connors stuff
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
            //connors stuff
            droneShooting = true;
            droneAnimation.GetComponent<Animator>().SetBool("droneShooting", droneShooting);
            //connors stuff
            Instantiate(bullet, shootOrigin.transform.position, shootOrigin.transform.rotation);
            shootTimer = shootTimerStart;


        }
    }
}
