using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject bullet; //Your set-up prefab
    public float shootingPower = 20f; //force of projection
    public float shootDistance = 8f;

    public float timeBtwShots;
    public float startTimeBtwShots = 2f;

    public int maxHealth = 100; //Max health level set
    public GameObject deathEffect;
    public HealthBar healthBar; //health bar 
    public GameObject healthB;

    void Start() 
    {
        healthBar.SetMaxHealth(maxHealth); //at the start of the game the healthbar is set with maximum health
        timeBtwShots = startTimeBtwShots; //set time between start as the start time 
    }

    private void Update()
    {
        //moves the weapon from the enemy character
        if (Vector2.Distance(transform.position, target.position) <= shootDistance) 
        {
            Fire(); //Constantly fire
        }

    }

    //method that fires a weapon from the enemy
    public virtual void Fire()
    {
        if (timeBtwShots <= 0)
        {
            //Shooting logic 
            Instantiate(bullet, weaponMuzzle.position, weaponMuzzle.rotation);
            timeBtwShots = startTimeBtwShots;

        }
        else 
        {
            timeBtwShots -= Time.deltaTime; //reduces variable that sets a time constraint on when the next enemy can fire a fireball
        }
        
    }

    //method which reduces the enemy health bar based on the damage recieved from the object hit
    public virtual void TakeDamage(int damage)
    {
        maxHealth -= damage;
        healthBar.SetHealth(maxHealth);

        //when the health of the character is less then 0, the character dies
        if (maxHealth <= 0)
        {
            Die();
        }
    }

    // Die method which removes the character from the scree
    public virtual void Die()
    {
        healthB.SetActive(false);//the healthBar object is removed from the screen
        Destroy(gameObject);//the character is removed from the screen 
    }
}
