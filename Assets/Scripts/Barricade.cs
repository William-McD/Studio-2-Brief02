using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    //Nathan's code
    //calls the BarricadeManager script
    public BarricadeManager script;
    // Start is called before the first frame update
    void Start()
    {
       this.gameObject.GetComponent<BarricadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((script.barricadeHP == 1) && (script.barricadeHealth <= 85))
        {
            script.barricadeHP = script.barricadeHP + 1;
            Destroy(this.gameObject);
        }
        if ((script.barricadeHP == 2) && (script.barricadeHealth <= 65))
        {
            script.barricadeHP = script.barricadeHP + 1;
            Destroy(this.gameObject);
        }
        if ((script.barricadeHP == 3) && (script.barricadeHealth <= 35))
        {
            script.barricadeHP = script.barricadeHP + 1;
            Destroy(this.gameObject);
        }
        if ((script.barricadeHP == 4) && (script.barricadeHealth <= 10))
        {
            script.barricadeHP = script.barricadeHP + 1;
            Destroy(this.gameObject);
        }
        if ((script.barricadeHP == 5) && (script.barricadeHealth <= 1))
        {
            Destroy(this.gameObject);
        }
    }
}
