using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //public Animator animator;
    public Transform firePoint;
    public Animator animation;
    public GameObject bulletPrefab;
    public GameObject target;

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


    }


    void Shoot()
    {
        //Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
<<<<<<< Updated upstream
        shoot = true;

=======
>>>>>>> Stashed changes
        //animator.SetBool("IsShooting", shoot);

    }
}
