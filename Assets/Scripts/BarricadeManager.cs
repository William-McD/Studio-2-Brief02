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

    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");
    }

    // Start is called before the first frame update
    void Start()
    {
       
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
