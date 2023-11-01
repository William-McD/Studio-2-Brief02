using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject barricade;
    public GameObject player;
    public GameObject currentTarget;

    public float speed;

    private float barricadeDistance;
    private float playerDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    //MASSIVE NOTE: Will need to change targeting system of enemy AI to target both players and barricade, also to target the CLOSEST player and the CLOSEST barricade

    // Update is called once per frame
    void Update()
    {
        barricadeDistance = Vector2.Distance(transform.position, barricade.transform.position); // get distance between barricade and enemy 
        playerDistance = Vector2.Distance(transform.position, player.transform.position); // get distance between player and enemy

        Vector2 direction = new Vector2(barricade.transform.position.x - transform.position.x, barricade.transform.position.y - transform.position.y);
        transform.up = direction;

        //Sets the enemy to move towards its current target
        transform.position = Vector2.MoveTowards(this.transform.position, barricade.transform.position, speed * Time.deltaTime);

    }
}

