using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public variables to be set in inspector
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    //other objects to hide in inspector
    [HideInInspector]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animation;

    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) //based on object cooldown
        {
            if (Input.GetButtonDown("Fire1")) //if the input occurs, the object will shoot the weapon
            {
                Shoot(); //shoot is instantiated
                nextAttackTime = Time.time + 1f / attackRate; //reset cooldown time
            }
        }

    }


    void Shoot() 
    {
        //Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animation.SetTrigger("IsShoot"); //animator is set


    }
}
