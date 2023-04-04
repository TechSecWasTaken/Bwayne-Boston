using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpStrength;

    private Rigidbody2D rb;
    private PlayerControls controls;
    private bool isgrounded;
    private float movement;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        controls = new PlayerControls();
        controls.Player.Jump.started += _ => Jump();
        controls.Player.Movement.performed += ctx => movement = ctx.ReadValue<float>();
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
        }
    }

}



