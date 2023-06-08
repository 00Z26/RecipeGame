using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public CapsuleCollider2D coll;
    public GameObject talkNPC;
    [Header("状态")]
    public bool isGround;
    public bool isInWater;
    public bool isDialogue;//在对话范围内
    public bool isAutoDialogue;
    public int thisLoopOpenDoorTimes;

    [Header("参数")]
    public Vector2 bottomOffset;
    public float checkRaduis; //碰撞体的检测范围
    public LayerMask groundLayer; //碰撞检测的所在层

    public void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        thisLoopOpenDoorTimes = 0;
    }
    void Update()
    {
        Check();
        //if(isDialogue == true && !GameObject.Find("DialogueBackground"))
        //{
        //    isDialogue = false; 
        //}'
        CheckDoorTimes();
    }

    private void OnEnable()
    {
        EventHandler.ExitDialogueState += OnResetInDialogue;
    }
    private void OnDisable()
    {
        EventHandler.ExitDialogueState -= OnResetInDialogue;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //自动对话范围触发
        if (collision.gameObject.tag == "AutoDialogue")
        {
            talkNPC = collision.gameObject.transform.parent.gameObject;
            isAutoDialogue = true;
            EventHandler.CallTriggerAutoDialogue();
            
            
        }
        if (collision.gameObject.tag == "NPC")
        {

            isDialogue = true;
            //Debug.Log(isDialogue);
            talkNPC = collision.gameObject;
            EventHandler.CallShowTipButtonEvent(isDialogue);
        }
    }

    private void OnResetInDialogue(bool dialogueVanish)
    {
        isDialogue = dialogueVanish;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {  
        //行动检测
        if(collision.gameObject.layer == LayerMask.NameToLayer("Water")) //4是water所在层
        {
            isInWater = true;
        }
        //if (collision.gameObject.tag == "NPC")
        //{   
            
        //    isDialogue = true;
        //    //Debug.Log(isDialogue);
        //    talkNPC = collision.gameObject;
        //    EventHandler.CallShowTipButtonEvent(isDialogue);
        //}

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water")) 
        {
            isInWater = false;
        }
        if ((collision.gameObject.tag == "NPC" || collision.gameObject.tag == "AutoDialogue") && !GameObject.Find("DialogueBackground"))
        {
            isDialogue = false;
            EventHandler.CallShowTipButtonEvent(isDialogue);
        }
        if (collision.gameObject.tag == "AutoDialogue")
        {
            isAutoDialogue = false;
        }
    }

    private void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
    private void CheckDoorTimes()
    {
       if(thisLoopOpenDoorTimes == 4)
        {
            SwapScene[] swapObjs = GameObject.FindObjectsOfType<SwapScene>();
            foreach(SwapScene obj in swapObjs)
            {
                if(obj.gameObject.name != "Cook2")
                {
                    //obj.enabled = false;
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    obj.gameObject.GetComponent<SpriteRenderer>().color = new Color32(152, 92, 92, 255);
                }
            }
        }
    }


}
