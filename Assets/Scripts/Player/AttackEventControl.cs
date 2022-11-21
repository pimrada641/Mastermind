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
    void EndAttack(){
        animator.ResetTrigger("Attack");
        Debug.Log("End Attack");
    }
     void EndHit(){
        animator.ResetTrigger("Hit");
     }
}
