using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSorcererMove : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Animator anim;   
    private bool ev = false;
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject bullet; //Your set-up prefab
    public float shootingPower = 20f; //force of projection
    private int maxHealth = 100;
    public HealthBar healthBar;
    public GameObject healthB;
    private float timeBtwShots;
    public float startTimeBtwShots = 2f;


    void Start() {
        healthBar.SetMaxHealth(maxHealth);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    } 
    public void Move() 
    {
        if(target.position.x >= 64) {
            anim.SetBool("OnEnter", true);
            ev = true;
        }
        if(ev == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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