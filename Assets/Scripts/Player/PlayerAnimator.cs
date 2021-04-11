using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;
    private bool _isJumping;

    private void Update()
    {
        if (_isJumping == false) 
            return;
        
        if(rigidbody.velocity.y < 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
    }

    public void SetJumpState(bool value)
    {
        _isJumping = value;
        if(value)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }
    }
    
}
