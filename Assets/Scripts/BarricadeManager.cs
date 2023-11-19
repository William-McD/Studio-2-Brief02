using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BarricadeManager : MonoBehaviour
{
    public int barricadeHealth;
    public TMP_Text barricadeText;
    GameObject[] barricades;

    public GameObject drone01;
    public GameObject drone02;
    public GameObject drone03;
    //public List <GameObject> droneList = new List <GameObject>();
    public int droneCount;

    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");
        drone01.SetActive(false);
        drone02.SetActive(false);
        drone03.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        barricadeText.text = (barricadeHealth + "%");
        if (barricadeHealth <= 0)
        {
            DestroyBarricade();
        }
        else
        {
            foreach (GameObject b in barricades)
            {
                b.SetActive(true);
            }    
        }
    }
    void DestroyBarricade()
    {
        foreach (GameObject b in barricades)
        {
            b.SetActive(false);
        }
    }

    public void DroneManager()
    {
        if (droneCount == 1 && (drone01.activeInHierarchy || drone02.activeInHierarchy || drone03.activeInHierarchy))
        {
            return;        
        }
        else if (droneCount == 1)
        {
            drone01.SetActive(true);
        }
        if (droneCount == 2 && (drone01.activeInHierarchy && drone03.activeInHierarchy))
        {
            return;
        }
        else if (droneCount == 2)
        { 
            drone02.SetActive(true);
        }
        if (droneCount == 3)
        {
            drone01.SetActive(true);
            drone02.SetActive(true);
            drone03.SetActive(true);
        }
        
    }

}
