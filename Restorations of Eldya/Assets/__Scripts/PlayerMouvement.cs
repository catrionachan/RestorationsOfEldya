using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    //float verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public float health = 200f;
    //public float currentHealth;
    public GameObject deathEffect;
    private int yMin = -10;
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = health;
        healthBar.SetMaxHealth(health);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0) {
            
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//takes positive value of speed and assigns it to "Speed" in animator


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;//takes left and right input and multiplies by speed 
        
        if (Input.GetButtonDown("Jump")) //takes up down inputs and sets jump to true 
        {
            jump = true;
            animator.SetBool("IsJumping", true);//takes  value of jump and assigns it to "IsJumping" in animator
        }

        if (Input.GetButtonDown("Crouch")) //takes up down inputs and sets crouch to true 
        {
            crouch = true;

        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

        if (transform.position.y <= yMin) 
        {
            Die();
        }
        
        }
        else {
            horizontalMove = 0;
        }
        

    }

    public void onLanding() 
    {
        animator.SetBool("IsJumping", false);
    }
    
    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//move our character 
        jump = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            animator.SetTrigger("IsDead");
            Invoke("Die", 0.7f);
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }
    


}
