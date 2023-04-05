using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpStrength;

    private Rigidbody2D rb;
    private PlayerControls controls;
    private bool isgrounded;
    private bool doubleJump;
    private float movement;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        controls = new PlayerControls();
        controls.Player.Jump.started += _ => Jump();
        controls.Player.Movement.performed += ctx => movement = ctx.ReadValue<float>();

        // This line stops movement when the button is released. remove if you want funny movement.
        controls.Player.Movement.canceled += _ => movement = 0;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();    

    // Update is called once per frame
    private void Update()
    {
        if(movement < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (movement > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 20;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 10;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isgrounded)
        {
        rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        } 
        else if (doubleJump) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength*0.785f);
            doubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
            doubleJump = true;
        }
    }

    

}



