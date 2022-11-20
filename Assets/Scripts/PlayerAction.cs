using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    int punch;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("Punch", punch);

        if(Input.GetMouseButtonDown(0)){
            // StopAllCoroutines();
            checkIsAttack();
            Attack();
            StartCoroutine(CheckAttackStage());
        }
    }
    void Attack(){
        punch+=1;   
        animator.SetTrigger("Attack");
    }
    void checkIsAttack(){
        if(animator.GetBool("Attack")==true){
            gameObject.transform.Find("AttackPoint").GetComponent<AttackPoint>().enabled = true;
        }
        else{
            gameObject.transform.Find("AttackPoint").GetComponent<AttackPoint>().enabled = false;
        }
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
        animator.ResetTrigger("Attack");
        StopAllCoroutines();
        // if(Input.GetMouseButtonDown(0)){
        //     if(punch==2){
        //         punch=0;
        //     }
        // }
        // else{
        //     punch=0;
        // }
    }
}
