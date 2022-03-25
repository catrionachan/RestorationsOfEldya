using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animation;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }


    void Shoot() 
    {
        //Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animation.SetTrigger("IsShoot");


    }
}
