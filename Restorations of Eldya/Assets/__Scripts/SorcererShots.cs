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
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            PlayerMovement player = hitInfo.GetComponent<PlayerMovement>(); //gets the hit info based on the PlayerMovement class
            //update player health and removes the gameObject
            if (player != null)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
