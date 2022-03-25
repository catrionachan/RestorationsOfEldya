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

            if (player != null)
            {
                player.TakeDamage(damage);//player health is updated on collision
            }
        }

    }
}
