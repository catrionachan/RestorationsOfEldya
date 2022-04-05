using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMinionEnemy : Enemy
{
    public Animator anim;
    private bool ev = false;
    public float speed;
    public bool isFlipped = false;
    public int counter = 0;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth); //sets the inital health as max
        
    }

    private void Update()
    {
        LookAtPlayer(); //Method to have the enemy follow the hero character

        if (target.position.x >= transform.position.x-2)
        {
            anim.SetBool("OnEnter", true); //starts animator OnEnter
            Debug.Log("startAnimation");
            ev = true; //variable is set as try
        }


        if (ev == true) //move towards the hero character
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            counter++;
        }
        if (counter == 800) {
            anim.SetBool("Explode", true); //starts animator Explode
            Explode();
        }

    }

    //method to explode
    public void Explode()
    {
        Debug.Log("fireExplosion");
        //Instantiate(bullet, weaponMuzzle.position, weaponMuzzle.rotation);
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

    // Die method which removes the character from the scree
    public override void Die()
    {
        healthB.SetActive(false);//the healthBar object is removed from the screen
        Destroy(gameObject);//the character is removed from the screen 
    }
}
