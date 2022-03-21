using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMinionMove : MonoBehaviour 
{
    //Sets the value of speed in the Inspector
    [Header("Set in Inspector")]
    public float speed = 1f; //speed in m/s

    [HideInInspector]
    //variable for BoundsCheck
    public BoundsCheck bndCheck;

    private int fireSpawn;
    private int counter = 0;
    //public Animator animatorController;
    //Awake method that gets the Components of BoundsCheck
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

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
        float randNum = Random.Range(300f, 700f);
        fireSpawn = (int)randNum;
        //animatorController = GetComponent<animatorController>();
    }
    // Update is called once per frame
    void Update()
    {
        Move(); //calls move method 
        counter++;
        if (counter == fireSpawn)
        {
            //animatorController.SetBool("isAttack", true);
            counter = 0;
        }
        else if (counter == 200) {
            //animatorController.SetBool("isAttack", false);
        }
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
        //if (bndCheck != null && pos.x=-3)

        if (pos.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
