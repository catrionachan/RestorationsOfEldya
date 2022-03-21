using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMover : MonoBehaviour
{
        //Sets the value of speed in the Inspector
    [Header("Set in Inspector")]
    public float speed = 2f; //speed in m/s

    private int fireSpawn;
      
    //Property of the Vector3 representing the position of the object
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    //
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Move(); //calls move method 
        CheckBounds(); //checks if enemy is within the bounds of the screen
    }

    //Move method which moves the enemy down the screen at the given speed
    public virtual void Move()
    {
        //creates Vector3 object which holds the value of the temporary position
        Vector3 tempPos = pos;
        //sets the temporary position of the enemy down the screen based on the speed of the enemy
        tempPos.x -= speed * Time.deltaTime;
        //sets the position of the enemy based on the temporary position
        pos = tempPos;
    }
    //CheckBounds method checks if the enemy has passed the bottom of the screen
    public virtual void CheckBounds()
    {
        ////if the enemy object is off the screen at the bottom, it destroys the object
        

        if (pos.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
