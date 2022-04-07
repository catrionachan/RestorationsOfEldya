using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatAstro : MonoBehaviour
{
    //Variables for the attack range, damage, rate, attack time and animator
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    private float attackRate = 4f;
    float nextAttackTime = 0f;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        //based on the cooldown time, if the control button is pressed, the attack method can be invoked
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;  //resets cooldown

            }
        }

    }

    //method for Attack
    void Attack()
    {
        animator.SetTrigger("IsHit");//sets animation to true 


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//creates a circle of radius and collects all objects hit 

        //each time an enemy is hit, damage is taken for the enemy and boss
        foreach (Collider2D each in hitEnemies)
        {
            each.GetComponent<Enemy>().TakeDamage(attackDamage);
            //each.GetComponent<EnemyBoss>().TakeDamage(attackDamage);
            //each.GetComponent<EnemyBoss2>().TakeDamage(attackDamage);
            //each.GetComponent<BombMinionEnemy>().TakeDamage(attackDamage);

        }
    }

    //debugging to draw sphere for testing
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
