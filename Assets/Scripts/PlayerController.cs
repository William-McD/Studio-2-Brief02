using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    public Studio2Brief2Team1 playerControls;


    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new Studio2Brief2Team1 ();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAim();

        moveDirection = move.ReadValue<Vector2>();

    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
    }

    public void PlayerAim()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
