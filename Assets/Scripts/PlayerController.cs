using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Healt Variables
    public bool alive;

    //Shooting Variables
    public GameObject bullet;
    GameObject child;

    public bool overheated;

    public float gunOverheatLimit;
    [SerializeField] float gunHeatUpAmount;
    public float gunCooldown;
    public Slider cooldownBar;


    //Movement Variables
    public Studio2Brief2Team1 playerControls;   //calls upon Input Manager setting to playerControls in the script

    public Rigidbody2D rb; //variable for rigidbody
    public float moveSpeed = 5f; // contains the set speed of the player characters movement

    Vector2 moveDirection = Vector2.zero;
    private InputAction move; // sets up InputAction for moving with move
    private InputAction fire; // sets up InputACtion for firing with fire
    private InputAction cooldown; // sets up InputAction for coolingdown with cooldown




    //connors stuff
    public GameObject playerAnimation;
    public bool isShooting;
    public float shootingAnimationTimer;
    //connors stuff

    private void Awake()
    {
        alive = true;
        playerControls = new Studio2Brief2Team1 ();
        child = transform.GetChild(0).gameObject; //set child as the first child of THIS gameObject (BulletSpawn)

        //connors work
        overheated = false;//check later
        isShooting = false;
        //connors work
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

        cooldown = playerControls.Player.Cooldown; // assomgs cpp;dpwm to the playerControls Input Cooldown (Spacebar)
        cooldown.Enable();
        cooldown.performed += ActiveCooldown;
    }
    private void OnDisable()
    {
        //when not using Fire or Move, disable them
        move.Disable();
        fire.Disable();
        cooldown.Disable();
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


        //connors stuff
        IsShooting();

        PlayerAnimationOverheating();
        PlayerAnimationShooting();
        //connors stuff
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }
    public void FiringCooldown()
    {
        //make the cooldownBar represent the gunCooldown
        cooldownBar.value = gunCooldown / gunOverheatLimit;

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

    public void ActiveCooldown(InputAction.CallbackContext context)
    {
        if (overheated == true && alive == true && (gunCooldown > 0))
        {
            gunCooldown -= (gunOverheatLimit / 10);
        }
    }
    public void Fire(InputAction.CallbackContext context) //when called, inact firing function
    {
        if (overheated == false && alive == true)
        {
            //connors stuff
            isShooting = true;
            //connors stuff
            Debug.Log("Fire!");
            Instantiate(bullet, child.transform.position, child.transform.rotation);
            gunCooldown += gunHeatUpAmount;
        }
        else
        {
            Debug.Log("Recharging!");

            //connors stuff
            isShooting = false;
            //connors stuff
        }
            }

    public void PlayerAim()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }


    //connors work

    public void PlayerAnimationOverheating()
    {
        playerAnimation.GetComponent<Animator>().SetBool("isOverheating", overheated);
    }

    public void PlayerAnimationShooting()
    {
        playerAnimation.GetComponent<Animator>().SetBool("isShooting", isShooting);
    }

    public void IsShooting()
    {
        if (isShooting == false)
        {
            shootingAnimationTimer = .3f;
        }

        if (isShooting == true)
        {
            shootingAnimationTimer -= Time.deltaTime;
            if (shootingAnimationTimer <= 0f) 
            {
                shootingAnimationTimer = .3f;
                isShooting = false;
            }
        }
    }
    //connors work
}
