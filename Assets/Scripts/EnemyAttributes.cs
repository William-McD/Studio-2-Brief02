using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    //connors stuff
    public GameObject enemyAnimation;
    public bool isdead;
    public float deathTimer;
    public bool isattacking;
    //connors stuff


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
        if (health > 0)
        {
            deathTimer = .4f;
        }
        if (health <= 0)
        {
            // connor work
            enemyAnimation.GetComponent<Animator>().SetBool("ZombieDeath", true);

            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0f)
            {
                Destroy(gameObject);
            }
            // connor work
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
            // connor work
            enemyAnimation.GetComponent<Animator>().SetBool("ZombieAttacking", true);
            // connor work
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (attackTimer <= 0)
            {
                barricadeManager.GetComponent<BarricadeManager>().barricadeHealth -= attackDamage;
                AttackDrone();
                attackTimer = attackTimerStart;
            }
        }
        else
        {
            // connor work
            enemyAnimation.GetComponent<Animator>().SetBool("ZombieAttacking", false);
            // connor work
        }
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player") && barricadeManager.GetComponent<BarricadeManager>().barricadeHealth <= 0)
        {
            player.GetComponent<PlayerController>().alive = false;
        }
    }

    void AttackDrone()
    {
        GameObject currentBarricade = GetComponent<EnemyChase>().barricade;
        int randomNum = Random.Range(0, 100);
        if (randomNum <= 20)
        {
            if (currentBarricade.name == "Barricade01" || currentBarricade.name == "Barricade02")
            {
                Debug.Log("Do damage against Drone01");
            }
            else if (currentBarricade.name == "Barricade03" || currentBarricade.name == "Barricade04")
            {
                Debug.Log("Do damage against Drone02");
            }
            else if (currentBarricade.name == "Barricade05" || currentBarricade.name == "Barricade06")
            {
                Debug.Log("Do damage against Drone03");
            }
            else
            {
                Debug.Log("There isn't any drones");                
            }
        }
    }
}
