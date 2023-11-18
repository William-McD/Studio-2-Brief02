using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    public int health;
    public int startingHealth;
    // Start is called before the first frame update
    void Awake()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject barricadeManager = GameObject.FindGameObjectWithTag("BarricadeManager");
            barricadeManager.GetComponent<BarricadeManager>().droneCount -= 1;
            gameObject.SetActive(false);
        }
    }
}
