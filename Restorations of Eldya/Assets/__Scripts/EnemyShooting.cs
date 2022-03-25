using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Objects to set for attack and shooting
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //Variables for the Animator, Transform and GameObject
    [HideInInspector]
    public Transform firePoint;
    public Animator animation;
    public GameObject bulletPrefab;
    public GameObject target;


    // Update is called once per frame
    void Update()
    {
        //if the time is greater than the next attack time the enemy shoots their weapon
        if (Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
           
        }


    }


    void Shoot()
    {
        //Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
