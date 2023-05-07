using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    //获取到方向键传入的二维向量
    public Vector2 inputDirection;
    
    [Header("基本参数")]
    public float speed;
    public float swimSpeed;
    public float jumpForce;
    public float swimJumpForce;
    public float swimGravity;
    public float groundGravity;



    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        groundGravity = rb.gravityScale;

        inputControl.Gameplay.Jump.started += Jump;
    }



    private void OnEnable()
    {
        inputControl.Enable();
    }
    private void OnDisable()
    {
        inputControl?.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        if (physicsCheck.isInWater)
        {
            Swim();
        }
    }
    
    private void FixedUpdate()
    {
            Move();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            if (rb.velocity.y < -9)
            {
                Debug.Log("入水");
                rb.AddForce( 2f * (groundGravity - swimGravity) * transform.up, ForceMode2D.Impulse); //(rb.gravityScale - swimGravity)

            }
        }
    }


    public void Move()
    {
        if (physicsCheck.isInWater)
        {
            rb.gravityScale = swimGravity;
        }
        else
        {
            rb.gravityScale = groundGravity;
        }
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if(physicsCheck.isGround == true)
        {
            rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
        }
        //if (physicsCheck.isInWater == true)
        //{
        //    rb.AddForce(swimJumpForce * transform.up, ForceMode2D.Impulse);
        //}
    }

    private void Swim()
    {
        if(Keyboard.current.wKey.isPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, swimSpeed * Time.deltaTime);
        }
    }
}
