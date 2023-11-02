using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Healt Variables
    public bool alive;

    //Shooting Variables
    public GameObject bullet;
    public GameObject child;

    [SerializeField] bool overheated;

    public float gunOverheatLimit;
    [SerializeField] float gunHeatUpAmount;
    public float gunOverheatImprovement;
    [SerializeField] float gunCooldown;

    //Movement Variables
    public Studio2Brief2Team1 playerControls;   //calls upon Input Manager setting to playerControls in the script

    public Rigidbody2D rb; //variable for rigidbody
    public float moveSpeed = 5f; // contains the set speed of the player characters movement

    Vector2 moveDirection = Vector2.zero;
    private InputAction move; // sets up InputAction for moving with move
    private InputAction fire; // sets up InputACtion for firing with fire

    private void Awake()
    {
        alive = true;
        playerControls = new Studio2Brief2Team1 ();
        child = transform.GetChild(0).gameObject; //set child as the first child of THIS gameObject (BulletSpawn)


        overheated = false;
        gunOverheatLimit = gunOverheatImprovement;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move; // assign move to playerControls Input Move (WASD)
        move.Enable(); // enables move actions

        fire = playerControls.Player.Fire; // assigns fire to playerControls Input Fire (Left Mouseclick)
        fire.Enable(); // enables fire action
        fire.performed += Fire; //the Fire action equals the Fire Function
    }
    private void OnDisable()
    {
        //when not using Fire or Move, disable them
        move.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            PlayerAim(); // calls function to aim player at cursor
            moveDirection = move.ReadValue<Vector2>();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // sets up velocity of player character
        FiringCooldown();

    }

    public void FiringCooldown()
    {
        if (overheated == false && gunCooldown > 0)
        {
            gunCooldown -= Time.deltaTime;
        }

        if (gunCooldown >= gunOverheatLimit)
        {
            overheated = true;
            gunCooldown = gunOverheatLimit;
        }

        if (overheated == true && alive == true)
        {
            gunCooldown -= Time.deltaTime;
            if (gunCooldown <= 0)
            {
                overheated = false;
                gunCooldown = 0;
            }
        }
    }
    public void Fire(InputAction.CallbackContext context) //when called, inact firing function
    {
        if (overheated == false && alive == true)
        {

            Debug.Log("Fire!");
            Instantiate(bullet, child.transform.position, child.transform.rotation);
            gunCooldown += gunHeatUpAmount;
        }
        else
        {
            Debug.Log("Recharging!");
        }
            
       

    }

    public void PlayerAim()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
