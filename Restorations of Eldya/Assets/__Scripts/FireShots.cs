using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShots : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 25;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        EnemyBoss enemyBoss = hitInfo.GetComponent<EnemyBoss>();

        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }

        if (enemyBoss != null)
        {
            enemyBoss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
