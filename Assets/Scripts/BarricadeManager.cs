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
    List <GameObject> droneList = new List <GameObject>();

    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");
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
}
