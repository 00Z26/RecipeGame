using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public CapsuleCollider2D coll;
    public GameObject talkNPC;
    [Header("״̬")]
    public bool isGround;
    public bool isInWater;
    public bool isDialogue;//�ڶԻ���Χ��

    [Header("����")]
    public Vector2 bottomOffset;
    public float checkRaduis; //��ײ��ļ�ⷶΧ
    public LayerMask groundLayer; //��ײ�������ڲ�

    public void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        Check();       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {  
        //�ж����
        if(collision.gameObject.layer == LayerMask.NameToLayer("Water")) //4��water���ڲ�
        {
            isInWater = true;
        }
        if (collision.gameObject.tag == "NPC")
        {
            isDialogue = true;
            talkNPC = collision.gameObject;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water")) 
        {
            isInWater = false;
        }
        if (collision.gameObject.tag == "NPC")
        {
            isDialogue = false;
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
}
