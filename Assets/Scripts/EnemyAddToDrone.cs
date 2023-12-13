using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAddToDrone : MonoBehaviour
{
    public GameObject[] drones;
    public bool enemyAdded;
    private void Awake()
    {
        enemyAdded = false;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drones = GameObject.FindGameObjectsWithTag("Drone");

        if (enemyAdded == false) 
        { 
            foreach (GameObject drone in drones)
            {
                if (drone.GetComponent<DroneAim>().enemyList.Contains(gameObject))
                {
                    return;
                }
                else
                {
                    drone.GetComponent<DroneAim>().enemyList.Add(gameObject);
                    enemyAdded = true;

                }
            }
        }

        if (GetComponent<EnemyAttributes>().health <= 0)
        {
            foreach (GameObject drone in drones)
            {
                drone.GetComponent<DroneAim>().enemyList.Remove(gameObject);
            }
        }
    }
}
