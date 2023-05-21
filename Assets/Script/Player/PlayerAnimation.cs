using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        //animator = this.GetComponentInChildren<Animator>();
        //Debug.Log(animator.gameObject.name);
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        animator = this.GetComponentInChildren<Animator>();
        if (animator != null)
        {
            SetAnimation();
        }
        
    }
    public void SetAnimation()
    {
        //Debug.Log(rb.velocity.x);
        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
}
