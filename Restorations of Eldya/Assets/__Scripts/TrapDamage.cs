using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    //Variable for damage 
    public float damage = 100f;
    public GameObject player;
    //when object collides with the character damage is inflicted
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();//sets collider with PlayerMovements
            PlayerMovementZoro player2 = collider.GetComponent<PlayerMovementZoro>();
            PlayerMovementAstro player3 = collider.GetComponent<PlayerMovementAstro>();

            if (player != null)
            {
                player.TakeDamage(damage);//player health is updated on collision
            }
            if (player2 != null)
            {
                player2.TakeDamage(damage);//player health is updated on collision
            }
            if (player3 != null)
            {
                //player3.TakeDamage(damage);//player health is updated on collision
            }
        }

    }
}
