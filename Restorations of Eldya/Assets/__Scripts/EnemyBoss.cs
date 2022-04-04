using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance with Enemy Class

public class EnemyBoss : Enemy
{
    public Animator anim;
    private bool ev = false;
    public float speed;
    public bool isFlipped = false;

    public EnemyBoss()
    {
        maxHealth = 1000;
    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth); //sets the inital health as max
        timeBtwShots = startTimeBtwShots; //sets initial time constraint between weapon spawining 
    }

    private void Update()
    {
        LookAtPlayer(); //Method to have the enemy follow the hero character

        if (target.position.x >= 64)
        {
            anim.SetBool("OnEnter", true); //starts animator OnEnter
            ev = true; //variable is set as try
        }


        if (ev == true) //move towards the hero character
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
       
           // if the hero character is within the shooting range of the hero, the enemy fires
        if (Vector2.Distance(transform.position, target.position) <= shootDistance)
        {
            Fire(); //Constantly fire
        }

    }

    //method to fire its weapon (combat style)
    public override void Fire()
    {
        if (timeBtwShots <= 0)
        {
            
            anim.SetTrigger("Attack1");

        }
        base.Fire();
    }
    
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > target.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < target.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
