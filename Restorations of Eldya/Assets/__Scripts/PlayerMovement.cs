using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
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
    public HealthBar expBar;
    public float experience = 0f;
    private float totalExp = 100f;




    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //currentHealth = health;
        healthBar.SetMaxHealth(health);
        expBar.SetMaxHealth(totalExp);
        expBar.SetHealth(experience);
        
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

        //invoke the die method
        if (transform.position.y <= yMin) 
        {
            Die();
        }
        
        }
        else {
            horizontalMove = 0;
        }
        

    }

    //Landing the jump animating
    public void onLanding() 
    {
        animator.SetBool("IsJumping", false);
    }
    
    //crouching movement animating
    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    //Movement for the character
    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//move our character 
        jump = false;
    }


    //Mehtod to take damage when the object gets hit
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

    //Mehtod to gain experience when the player collides with a potion 
    public void gainExperience(float exp)
    {
        experience += exp;
        expBar.SetHealth(experience);

        if (experience >= 100)
        {
            
        }
    }

    //removes gameObject and send to the gameOver Scene
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
    


}
