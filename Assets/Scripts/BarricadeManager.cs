using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BarricadeManager : MonoBehaviour
{

    //Nathan
    public GameObject prefabA;
    public GameObject prefabB;
    public GameObject prefabC;
    public GameObject prefabD;
    public GameObject prefabE;
    public bool ShieldedBarricade;
    public bool SlightlyDamaged;
    public bool HalfDamaged;
    public bool MostlyDamaged;
    public bool BarricadeDestroyed;
    public int barricadeHP;
    //Nathan
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
        //Nathan
        GameObject clone = Instantiate(prefabA, transform.position, transform.rotation);
        clone.GetComponent<Barricade>().script = this;
        barricadeHP = 1;
        //Nathan

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

        //Nathan
        if ((ShieldedBarricade == false) && (barricadeHP == 2))
        {
            GameObject clone = Instantiate(prefabB, transform.position, transform.rotation);
            clone.GetComponent<Barricade>().script = this;
            ShieldedBarricade = true;
        }
        if ((SlightlyDamaged == false) && (barricadeHP == 3))
        {
            GameObject clone = Instantiate(prefabB, transform.position, transform.rotation);
            clone.GetComponent<Barricade>().script = this;
            SlightlyDamaged = true;
        }
        if ((HalfDamaged == false) && (barricadeHP == 4))
        {
            GameObject clone = Instantiate(prefabB, transform.position, transform.rotation);
            clone.GetComponent<Barricade>().script = this;
            HalfDamaged = true;
        }
        if ((MostlyDamaged == false) && (barricadeHP == 5))
        {
            GameObject clone = Instantiate(prefabB, transform.position, transform.rotation);
            clone.GetComponent<Barricade>().script = this;
            MostlyDamaged = true;
        }
        if ((BarricadeDestroyed == false) && (barricadeHP == 6))
        {
            GameObject clone = Instantiate(prefabB, transform.position, transform.rotation);
            clone.GetComponent<Barricade>().script = this;
            BarricadeDestroyed = true;
        }
        //nathan
    }
    void DestroyBarricade()
    {
        foreach (GameObject b in barricades)
        {
            b.SetActive(false);
        }
    }
}
