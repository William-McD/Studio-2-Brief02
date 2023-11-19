using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddToDrone : MonoBehaviour
{
    public GameObject[] drones;

    private void Awake()
    {
        drones = GameObject.FindGameObjectsWithTag("Drone");
        foreach (GameObject drone in drones)
        {
            drone.GetComponent<DroneAim>().enemyList.Add(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyAttributes>().health == 0)
        {
            foreach (GameObject drone in drones)
            {
                drone.GetComponent<DroneAim>().enemyList.Remove(gameObject);
            }
        }
    }
}
