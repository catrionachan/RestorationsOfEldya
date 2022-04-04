using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionExp : MonoBehaviour
{
    private Transform player;
    public float expPoints = 1f;
    private Vector3 target;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);



    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //OnTrigger event which sees if the potion collides with player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();

            if (player != null) //if the play is not null, player gains the experience points 
            {
                player.gainExperience(expPoints);// gains experience points 
                Destroy(gameObject);//removes the projectile from the screen
            }
        }

    }
}
