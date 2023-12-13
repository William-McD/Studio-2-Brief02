using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject barricade;
    public GameObject barricadeManager;
    public GameObject player;
    public GameObject currentTarget;

    public GameObject[] barricades;

    [SerializeField] float speed; //how fast is the enemy
    public float startingSpeed;
    public float chargeSpeed; //for when the barricade is destroyed
    //Nathan
    public float obstacleSpeed;
    //Nathan

    public float barricadeDistance; // how fare is the barricade
    public float playerDistance; // how far is the player
    
    public bool isNotColliding; //whether the enemy is colliding with the barricade

    private float nearestDistance = 10000f;



    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");
        barricadeManager = GameObject.FindGameObjectWithTag("BarricadeManager");
        player = GameObject.FindGameObjectWithTag("Player");
        isNotColliding = true;
        speed = startingSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //MASSIVE NOTE: Will need to change targeting system of enemy AI to target both players and barricade, also to target the CLOSEST player and the CLOSEST barricade

    // Update is called once per frame
    void Update()
    {
        DetermineTarget();
        DetermineSpeed();
        //barricadeDistance = Vector2.Distance(transform.position, barricade.transform.position); // get distance between barricade and enemy 
        //playerDistance = Vector2.Distance(transform.position, player.transform.position); // get distance between player and enemy
        Vector2 direction = new Vector2(currentTarget.transform.position.x - transform.position.x, currentTarget.transform.position.y - transform.position.y);
        transform.up = direction;


        if (isNotColliding == true)
        {
            //Sets the enemy to move towards its current target

            transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))
        {
            isNotColliding = false;
        }
        //Nathan
        if (other.CompareTag("Obstacle"))
        {
            speed = obstacleSpeed;
        }
        //Nathan
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))
        {
            isNotColliding = true;
        }
        //Nathan
        if (other.CompareTag("Obstacle"))
        {
            speed = startingSpeed;
        }
        //Nathan
    }

    void DetermineSpeed()
    {
        if (barricadeManager.GetComponent<BarricadeManager>().barricadeHealth <= 0)
        {
            speed = chargeSpeed;
        }

    }
    void DetermineTarget()
    {
        if (barricadeManager.GetComponent<BarricadeManager>().barricadeHealth <= 19 )
        {
            FindPlayer();
        }
        else
        {
            FindClosestBarricade();
        }
    }

    void FindPlayer()
    {
        playerDistance = Vector2.Distance(transform.position, player.transform.position); // get distance between player and enemy
        currentTarget = player;
    }


    public void FindClosestBarricade()
    {
        for (int i = 0; i< barricades.Length; i++)
        {
            barricadeDistance = Vector2.Distance(transform.position, barricades[i].transform.position); // get distance between barricade and enemy 

            if(barricadeDistance < nearestDistance)
            {
                barricade = barricades[i];
                nearestDistance = barricadeDistance;

                currentTarget = barricade;
            }
        }
        /* UTTER NONSENSE (ATTEMPT AT USING A DICTIONARY, MAY TRY TO USE FOR SPAWN LIST! KEEP UNTIL UNEEDED)
        foreach (GameObject r in barricades) 
        {
            float distance = Vector2.Distance(transform.position, r.transform.position);
            barricadeDistances.Add(distance);
            
        }

        Dictionary<GameObject, float> distanceComparison = new Dictionary<GameObject, float>();
        for (int i = 0; i < barricades.Count(); i++)
        {
            distanceComparison.Add(barricades[i].gameObject, barricadeDistances[i]);
        }

        foreach(KeyValuePair<GameObject, float> dictionary in distanceComparison)
        {
            Debug.Log(dictionary.Key + ", " + dictionary.Value);
        }
        Debug.Log(distanceComparison.Values.Min());

        barricade = distanceComparison.Min(x => x.Key);
       // barricade = distanceComparison.Min(kvp => kvp.Key);
        */
    }
}

