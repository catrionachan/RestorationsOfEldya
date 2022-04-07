using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMinionEnemy : Enemy
{
    public Animator anim;
    private bool ev = false;
    public float speed;
    public bool isFlipped = false;
    public bool animate = false;
    private int counter = 0;
    public int damage;
    public PlayerMovement player;
    public PlayerMovementZoro playerZ;
    public PlayerMovementAstro playerA;

    void Start()
    {
        //healthBar.SetMaxHealth(maxHealth); //sets the inital health as max
        animate = false;
    }

    private void Update()
    {
        LookAtPlayer(); //Method to have the enemy follow the hero character
        PlayerEnters();

        if (ev == true) //move towards the hero character
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            counter++;
        }

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

    public void PlayerEnters()
    {

        if (target.position.x >= transform.position.x - 5)
        {
            anim.SetTrigger("OnEnter1"); //starts animator OnEnter
            ev = true; //variable is set as try
        }
        if (counter == 60)
        {
            anim.SetTrigger("OnEnter2"); //starts animator Explode
            
            if(target.position.x >= transform.position.x - 2 && target.position.x <= transform.position.x + 2 && playerZ != null)
            {
                playerZ.TakeDamage(damage);

            }
            if(target.position.x >= transform.position.x - 2 && target.position.x <= transform.position.x + 2 && player != null)
            {
                player.TakeDamage(damage);

            }
            if(target.position.x >= transform.position.x - 2 && target.position.x <= transform.position.x + 2 && playerA != null)
            {
               
                playerA.TakeDamage(damage);

            }
            Invoke("Die", 0.25f);
            
        }
        

    }
    
    //removes GameObject from the screen
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
