using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public float damage = 100f;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerMouvement player = collider.GetComponent<PlayerMouvement>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

    }
}
