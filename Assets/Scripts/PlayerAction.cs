using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    int punch;
    public Animator animator;
    public Animator enemyAnim;
    void Update()
    {
        //AttackSystem
        animator.SetInteger("Punch", punch);
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }
    void Attack(){
        punch+=1;   
        StartCoroutine(CheckAttackStage());
    }

    IEnumerator CheckAttackStage(){
        if(punch>3){            
            punch=0;
            yield return new WaitForSeconds(0.2f);
            StopAllCoroutines();
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Kick")){
            punch=0;
        }
        yield return new WaitForSeconds(0.6f);
        punch=0;
        StopAllCoroutines();
    }

    //Took Damage System
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Melee")){
            enemyAnim = other.GetComponentInParent<Animator>();

            if(enemyAnim.GetBool("Attack")==true){
                Debug.Log("Get Hit");
                animator.SetTrigger("Hit");
                enemyAnim.ResetTrigger("Attack");
            }
        }
        
    }

}
