using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    int punch;
    public Animator animator;
    public Animator enemyAnim;
    public int damage = 20;
    public PlayerHealth playerHealth;
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
        if(other.transform.CompareTag("Melee") && !other.transform.root.CompareTag("Player")){
            enemyAnim = other.transform.root.GetComponent<Animator>();
            // GameObject otherobj = other.gameObject;
            Debug.Log(other.transform.GetChild(0).gameObject);

            if( enemyAnim != null){
                CheckMelee(other.transform.GetChild(0).gameObject);
                // if(enemyAnim.GetBool("Attack")==true){
                    
                    // Debug.Log("Get Hit");
                    // this.playerHealth.TakeDamage(damage);
                    // animator.SetTrigger("Hit");
                    // enemyAnim.ResetTrigger("Attack");
                    // enemyAnim.ResetTrigger("LeftAttack");
                    // enemyAnim.ResetTrigger("RightAttack");
                    // enemyAnim.ResetTrigger("FootAttack");
                // }
            }
        }
    }

    void CheckMelee(GameObject other){

        if(other.gameObject.CompareTag("RightHand") && enemyAnim.GetBool("RightAttack")==true){
            Debug.Log("Get Hit: Right");
            this.playerHealth.TakeDamage(damage);
            animator.SetTrigger("Hit");
            enemyAnim.ResetTrigger("RightAttack");
        }
        else if(other.gameObject.CompareTag("LeftHand") && enemyAnim.GetBool("LeftAttack")==true){
            Debug.Log("Get Hit: Left");
            this.playerHealth.TakeDamage(damage);
            animator.SetTrigger("Hit");
            enemyAnim.ResetTrigger("LeftAttack");
        }
        else if(other.gameObject.CompareTag("Foot") && enemyAnim.GetBool("FootAttack")==true){
            Debug.Log("Get Hit: Foot");
            this.playerHealth.TakeDamage(damage);
            animator.SetTrigger("Hit");
            enemyAnim.ResetTrigger("FootAttack");
        }
    }

}
