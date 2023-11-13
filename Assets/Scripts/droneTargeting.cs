using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneTargeting : MonoBehaviour// this script was made by connor
{


    public GameObject bullet;
    public GameObject child;
    public GameObject zombie;
    public GameObject currentTarget;
    public float zombieDistance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zombie = GameObject.FindGameObjectWithTag("Enemy");

        Vector2 direction = new Vector2(currentTarget.transform.position.x - transform.position.x, currentTarget.transform.position.y - transform.position.y);
        transform.up = direction;

        if (zombieDistance > 4)
        {
            //Sets the drone to move towards its current target

            transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }
        else
        {
            // turn into a fuction thats to be called

            Instantiate(bullet, child.transform.position, child.transform.rotation);
        }
    }


    private void Awake()
    {
        //barricades = GameObject.FindGameObjectsWithTag("Barricade");
        //barricadeManager = GameObject.FindGameObjectWithTag("BarricadeManager");
        //child = transform.GetChild(0).gameObject;
        zombie = GameObject.FindGameObjectWithTag("Enemy");// check for any object with a tag that has "zombie" in it
    }


    void FindZombie()
    {
        zombieDistance = Vector2.Distance(transform.position, zombie.transform.position); // get distance between player and enemy
       // currentTarget = player;
    }

}
