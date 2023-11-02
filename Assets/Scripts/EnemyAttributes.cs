using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int health;
    public int startingHealth;

    public GameObject barricadeManager;
    bool atBarricade;

    [SerializeField] float attackTimer;
    public float attackTimerStart;

    public int attackDamage;

    private void Awake()
    {
        health = startingHealth;
        attackTimer = attackTimerStart;

        barricadeManager = GameObject.FindGameObjectWithTag("BarricadeManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        AttackingBarricade();
       
    }

    void AttackingBarricade()
    {
        if (GetComponent<EnemyChase>().isNotColliding == false)
        {
            atBarricade = true;
        }
        else
        {
            atBarricade = false;
        }

        if (atBarricade == true) 
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (attackTimer <= 0)
            {
                barricadeManager.GetComponent<BarricadeManager>().barricadeHealth -= attackDamage;
                attackTimer = attackTimerStart;
            }
        }
    }
}
