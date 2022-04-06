using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the main character fireshot
public class FireShots : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage = 25;

    // Start is called before the first frame update
    void Start()
    {
        //sets velocity
        rb.velocity = transform.right * speed;

        
    }

    //Trigger event for main character's fireball
    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        EnemyBoss enemyBoss = hitInfo.GetComponent<EnemyBoss>();

        //if the enemy gets hit with the fireball, the enemy health is updated
        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }
        //if the boss gets hit with the fireball, the enemy health is updated
        if (enemyBoss != null)
        {
            enemyBoss.TakeDamage(damage);
        }
        //removes gameObject from screen
        Destroy(gameObject);
    }


}
