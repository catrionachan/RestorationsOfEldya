using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMover : MonoBehaviour
{
        //Sets the value of speed in the Inspector
    [Header("Set in Inspector")]
    private Transform player;

    private Vector3 target;
    public int damage = 20;
    public float speed = 20f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
  
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player")) 
        {
            PlayerMouvement player = collider.GetComponent<PlayerMouvement>();

            if (player != null)
            {
                player.TakeDamage(damage);
                DestroyProjectile();
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            DestroyProjectile();

        }

    }

    void DestroyProjectile() 
    {
        Destroy(gameObject);
    }

}
