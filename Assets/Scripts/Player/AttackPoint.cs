using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public Animator enemyAnim;
    public Animator animator;
    void Start(){
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("OtherPlayer")){
            if(animator.GetBool("Attack")){
                enemyAnim = other.GetComponent<Animator>();
                enemyAnim.SetTrigger("Hit");
            }
        }
    }
}
