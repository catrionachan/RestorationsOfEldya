using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

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
            if (Input.GetButtonDown("Fire2"))
            {
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
        
    }

    void Attack() 
    {
        animator.SetBool("IsAttacking", true);//sets animation to true 


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//creates a circle of radius and collects all objects hit 

        foreach(Collider2D each in hitEnemies) 
        {
            each.GetComponent<Enemy>().TakeDamage(attackDamage);
            each.GetComponent<EnemyBoss>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null) 
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
