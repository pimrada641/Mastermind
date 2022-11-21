using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEventControl : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void BeginAttack(){
        Debug.Log("Begin Attack");
        animator.SetTrigger("Attack");
    }

    void RightAttack(){
        Debug.Log("Right Attack");
        animator.SetTrigger("RightAttack");
        animator.ResetTrigger("LeftAttack");
        animator.ResetTrigger("FootAttack");
    }
    void LeftAttack(){
        Debug.Log("Left Attack");
        animator.SetTrigger("LeftAttack");
        animator.ResetTrigger("RightAttack");
        animator.ResetTrigger("FootAttack");
    }
    void FootAttack(){
        Debug.Log("Foot Attack");
        animator.SetTrigger("FootAttack");
        animator.ResetTrigger("LeftAttack");
        animator.ResetTrigger("RightAttack");
    }
    void EndAttack(){
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("RightAttack");
        animator.ResetTrigger("LeftAttack");
        animator.ResetTrigger("FootAttack");
        Debug.Log("End Attack");
    }
     void EndHit(){
        animator.ResetTrigger("Hit");
     }
}
