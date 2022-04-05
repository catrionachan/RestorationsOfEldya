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
    public int counter = 0;
    public int damage = 100;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth); //sets the inital health as max
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

    public void PlayerEnters() {
        if (target.position.x >= transform.position.x - 2)
        {
            anim.SetTrigger("OnEnter1"); //starts animator OnEnter
            Debug.Log("startAnimation");
            ev = true; //variable is set as try
        }
        if (counter == 500 && animate ==false) {
            Debug.Log("fireExplosion");
            anim.SetTrigger("OnEnter2"); //starts animator Explode
            animate=true;
        }
        if (counter==520 ){
            Die();
        }

    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player") && animate==true) 
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();

            if (player != null) //if the play is not null, player takes the damage
            {
                player.TakeDamage(damage);
            }
        }
        
    }
}
