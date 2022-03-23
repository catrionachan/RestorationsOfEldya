using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject target;
    bool shoot = false;
    int count = 0;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(target.transform)
        if (Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
           
        }
        /*if (count >= 2000)
        {
            animator.SetBool("IsShooting", false);
        }*/


    }


    void Shoot()
    {
        //Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shoot = true;
        //animator.SetBool("IsShooting", shoot);

    }
}
