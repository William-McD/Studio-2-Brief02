using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneHealth : MonoBehaviour
{
    public int health;
    public int startingHealth;
    //Chris
    public GameObject droneUI;
    public Slider healthSlider;
    //Chris


    // Start is called before the first frame update
    void Awake()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Chris
        healthSlider.value = health;
        //Chris

        if (gameObject == true) 
        {
            droneUI.SetActive(true);
        }
        if (health <= 0) // Chris
        {
            GameObject barricadeManager = GameObject.FindGameObjectWithTag("BarricadeManager");
            barricadeManager.GetComponent<BarricadeManager>().droneCount -= 1;
            GetComponent<DroneAim>().enemyList.Clear();
            droneUI.SetActive(false);
            gameObject.SetActive(false);
            health = startingHealth;
        }
    }
}
