using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//point which changes the direction of the enemy object movement
public class Waypoint : MonoBehaviour
{

    //Sets the GameObject array for the wayboints
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++; //increase the index of the current waypoint
            transform.Rotate(0f, 180f, 0f); //rotate the object 180 degrees

            if (currentWaypointIndex >= waypoints.Length) //if the Index is greater or equal to the length the index is set to 0
            {
                currentWaypointIndex = 0;
                
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); //move the enemy towards the waypoint
    }
}
