using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeManager : MonoBehaviour
{
    public int barricadeHealthStart;
    public int barricadeHealth;
    
    [SerializeField] int numberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        barricadeHealth = barricadeHealthStart;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
