using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMover : MonoBehaviour
{
   
    private Transform player;
    private Vector3 target;
    //Sets the value of speed in the Inspector
    [Header("Set in Inspector")]
    public int damage = 20;
    public float speed = 20f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the velocity and target for the player
        rb.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
  
    // Update is called once per frame
    void Update()
    {
        //Destroys the projectile if the fireball hits the target
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    //OnTrigger event which sees if the fireball collides with player
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player")) 
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();

            if (player != null) //if the play is not null, player takes the damage
            {
                player.TakeDamage(damage);
                DestroyProjectile();//removes the projectile from the screen
            }
        }
        
    }

    //Destroys the fireball on the collision with an object

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            DestroyProjectile();

        }

    }

    //removes GameObject from the screen
    void DestroyProjectile() 
    {
        Destroy(gameObject);
    }

}
