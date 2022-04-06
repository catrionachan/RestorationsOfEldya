using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sorcerer Shooter class
public class SorcererShots : MonoBehaviour
{
    //variables to set speed and damage
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 25;

    // Start is called before the first frame update
    void Start()
    {
        //sets velocity based on speed
        rb.velocity = transform.right * speed;

    }

    //method for trigger for when the object collides with the player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();//sets collider with PlayerMovements
            PlayerMovementZoro player2 = collider.GetComponent<PlayerMovementZoro>();
            PlayerMovementAstro player3 = collider.GetComponent<PlayerMovementAstro>();

            if (player != null)
            {
                player.TakeDamage(damage);//player health is updated on collision
                Destroy(gameObject);
            }
            if (player2 != null)
            {
                player2.TakeDamage(damage);//player health is updated on collision
                Destroy(gameObject);
            }
            if (player3 != null)
            {
                //player3.TakeDamage(damage);//player health is updated on collision
                //Destroy(gameObject);
            }
        }
    }
}
