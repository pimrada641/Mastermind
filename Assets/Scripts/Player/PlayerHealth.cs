using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    CharacterController controller;
    PlayerMovement playerMovement;
    public int health;
    public int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        animator = Player.GetComponent<Animator>();
        controller = Player.GetComponent<CharacterController>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            Debug.Log("Dead");
            animator.SetBool("Dead",true);
            controller.enabled = false;
            playerMovement.enabled = false;
        }
    }
}