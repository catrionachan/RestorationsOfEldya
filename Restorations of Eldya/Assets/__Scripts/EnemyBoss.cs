using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject bullet; //Your set-up prefab
    public float shootingPower = 20f; //force of projection
    public float shootDistance = 5f;
    public Animator anim;
    private bool ev = false;
    public float speed;


    private float timeBtwShots;
    public float startTimeBtwShots = 2f;

    private int maxHealth = 500;
    public GameObject deathEffect;
    public HealthBar healthBar;
    public GameObject healthB;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (target.position.x >= 64)
        {
            anim.SetBool("OnEnter", true);
            ev = true;
        }
        if (ev == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            if (transform.position.x < target.position.x) 
            {
                transform.Rotate(0f, 180f, 0f);
            }
            

        }

        if (Vector2.Distance(transform.position, target.position) <= shootDistance)
        {
            Fire(); //Constantly fire
        }

    }

    private void Fire()
    {
        if (timeBtwShots <= 0)
        {
            //Shooting logic 
            Instantiate(bullet, weaponMuzzle.position, weaponMuzzle.rotation);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        healthBar.SetHealth(maxHealth);


        if (maxHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        healthB.SetActive(false);
        Destroy(gameObject);
    }
}
