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
    public bool isDialogueUI = false;

    public GameObject dialogueObj;
    [Header("基本参数")]
    public float speed;
    public float swimSpeed;
    public float jumpForce;
    public float swimJumpForce;
    public float swimGravity;
    public float groundGravity;
    public List<int> teamMembers;



    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        groundGravity = rb.gravityScale;

        teamMembers = new List<int>(); //统计小队里有谁
        //inputControl.Gameplay.Jump.started += Jump;
    }



    private void OnEnable()
    {
        inputControl.Enable();
        EventHandler.TriggerAutoDialogue += onTriggerAutoDialogue;
        EventHandler.UpdateDialogueState += SetTrueDialogueBool;
        EventHandler.ExitDialogueState += SetFalseDialogueBool;
    }
    private void OnDisable()
    {
        inputControl?.Disable();
        EventHandler.TriggerAutoDialogue -= onTriggerAutoDialogue;
        EventHandler.UpdateDialogueState -= SetTrueDialogueBool;
        EventHandler.ExitDialogueState -= SetFalseDialogueBool;
    }

    private void SetTrueDialogueBool(bool arg1, float arg2)
    {
        isDialogueUI = true;
    }

    private void SetFalseDialogueBool(bool obj)
    {
        isDialogueUI = false;
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        if (physicsCheck.isInWater)
        {
            Swim();
        }



            Talk();
        
    }
    
    private void FixedUpdate()
    {
        if(!isDialogueUI && GameObject.FindGameObjectWithTag("ESC") == null)
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

        float face = this.transform.localScale.x;
        if (inputDirection.x > 0)
        {
            face = Mathf.Abs(this.transform.localScale.x);
        }
        if (inputDirection.x < 0)
        {
            face = -MathF.Abs(this.transform.localScale.x);
        }
        this.transform.localScale = new Vector3(face, this.transform.localScale.y, this.transform.localScale.z);
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

    private void Talk()
    {
        if(GameObject.Find("Choice0") == null)
        {
            if ((Keyboard.current.eKey.wasPressedThisFrame && physicsCheck.isDialogue&& !GetDialogueUI() && GameObject.FindGameObjectWithTag("ESC") == null) 
                || (Mouse.current.leftButton.wasPressedThisFrame && GetDialogueUI() && GameObject.FindGameObjectWithTag("ESC") == null)
                || (Keyboard.current.spaceKey.wasPressedThisFrame && GetDialogueUI() && GameObject.FindGameObjectWithTag("ESC") == null))
            {   //按e触发对话
                Debug.Log("触发对话");
                if (GetDialogueUI())
                    EventHandler.CallPlayClickUIAudioEvent();
                physicsCheck.talkNPC.GetComponent<DialogueController>().ShowDialogue(physicsCheck.isAutoDialogue, this.gameObject);
                //EventHandler.CallTriggerDialogueEvent(physicsCheck.isAutoDialogue, this.gameObject);

            }
        }


    }

    private void onTriggerAutoDialogue()
    {
        //自动触发范围的事件，触发第一次自动对话，之后开启对话状态为true
        physicsCheck.talkNPC.GetComponent<DialogueController>().ShowDialogue(physicsCheck.isAutoDialogue, this.gameObject);
        physicsCheck.isDialogue = true;

    }

    private bool GetDialogueUI()
    {
        return dialogueObj.GetComponent<DialogueUI>().isDialogueOn;
    }

}
