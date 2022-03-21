using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    //Set the value in the Inspector
    [Header("Set in Inspector")]
    public float radius = 1f; //radius of the BoundsCheck
    public bool keepOnScreen = true; //to hold boolean value to keep the object on the screen

    [Header("Set Dynamically")]
    public bool onScreen = true; //boolean if the object is on the screen
    public float camWidth; //game camera width
    public float camHeight; //game camera height

    //boolean values that are not visible on the inspector
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    //Awake Method which sets the Height and Width of the game screen based on the Camera dimensions
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    //LateUpdate which ensures the object moves
    void LateUpdate()
    {
        //Vector3 object created based on the position of the object
        Vector3 pos = transform.position;
        onScreen = true;
        //sets the booleans to determine if off of the screen as false
        offRight = offLeft = offUp = offDown = false;
        //checks if the object X position is off of the screen to the right
        if (pos.x > camWidth - radius)
        {
            //sets the position of the object on the screen
            pos.x = camWidth - radius;
            //sets boolean value as true
            offRight = true;

        }
        //checks if the object X position is off of the screen to the left
        if (pos.x < -camWidth + radius)
        {
            //sets the position of the object on the screen
            pos.x = -camWidth + radius;
            offLeft = true; //sets boolean value as true
        }
        //checks if the object X position is off of the screen at the top
        if (pos.y > camHeight - radius)
        {
            //sets the position of the object on the screen
            pos.y = camHeight - radius;
            offUp = true;//sets boolean value as true
        }
        //checks if the object X position is off of the screen at the bottom
        if (pos.y < -camHeight + radius)
        {
            //sets the position of the object on the screen
            pos.y = -camHeight + radius;
            offDown = true;//sets boolean value as true
        }
        //Checks if any of the boolean values are true, the object is off the screen
        onScreen = !(offRight || offLeft || offUp || offDown);

        //if object is on screen, moves the position of the Object and sets values of off screen as false
        if (keepOnScreen && !onScreen)
        {
            //sets boolean value as true
            transform.position = pos;
            onScreen = true; //sets on Screen as tru
            offRight = offLeft = offUp = offDown = false;

        }
    }
}
