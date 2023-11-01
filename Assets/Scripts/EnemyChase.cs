using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject barricade;
    public GameObject player;
    public GameObject currentTarget;

    public GameObject[] barricades;

    public float speed;

    public float barricadeDistance;
    public float playerDistance;

    private float nearestDistance = 10000f;

    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");

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
        //barricadeDistance = Vector2.Distance(transform.position, barricade.transform.position); // get distance between barricade and enemy 
        //playerDistance = Vector2.Distance(transform.position, player.transform.position); // get distance between player and enemy

            Vector2 direction = new Vector2(currentTarget.transform.position.x - transform.position.x, currentTarget.transform.position.y - transform.position.y);
            transform.up = direction;

            //Sets the enemy to move towards its current target
            transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
    }
    void DetermineTarget()
    {
        if (barricades.Length == 0)
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
        /*
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

