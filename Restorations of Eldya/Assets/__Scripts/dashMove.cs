using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public GameObject dashEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                direction = 1;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                direction = 2;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 2)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }

            }
        }
    }
}
