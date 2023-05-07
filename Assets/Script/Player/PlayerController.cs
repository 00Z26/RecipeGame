using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    //获取到方向键传入的二维向量
    public Vector2 inputDirection;
    [Header("基本参数")]
    public float speed;
    public float jumpForce;


    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();

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
    }
    private void FixedUpdate()
    {
            Move();
        
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
    }

}
