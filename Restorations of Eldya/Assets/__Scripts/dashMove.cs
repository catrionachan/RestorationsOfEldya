using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class to implement Dash Movemet
public class DashMove : MonoBehaviour
{
    //All public and private variables for the class
    private Rigidbody2D rb; //2D rigidbody movement
    public float dashSpeed; //Varaible for speed
    private float dashTime; //Private variable for dash time
    public float startDashTime;
    private int direction; //integer to represent the direction
    public GameObject dashEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        //If direction is equal to 0 
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.C))//when C is pressed the dashEffect is instantiated and direction 1 is set
            {
                direction = 1;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Z)) //when Z is pressed, dashEffect is instantiated and direction is set to 2
            {
                direction = 2;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (dashTime <= 0) //if dashTime is 0 or negative number, the direction is set as 0 and velocity set as 0
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime; //dashTime is reduced

                if (direction == 2) //if direction is 2 the character moves to the left
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 1) //if direction is 1, the character moves to the right. 
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }

            }
        }
    }
}
