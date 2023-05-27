using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator[] animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        //animator = this.GetComponentInChildren<Animator>();
        //Debug.Log(animator.gameObject.name);
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //之后要改为对所有子物体获取组件
        animator = this.GetComponentsInChildren<Animator>();
        if (animator != null)
        {
            SetAnimation();
        }
        
    }
    public void SetAnimation()
    {
        //Debug.Log(rb.velocity.x);
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetBool("isFollow", true);
            animator[i].SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }
        
    }
}
