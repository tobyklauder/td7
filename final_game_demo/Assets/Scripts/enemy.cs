using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering;
/* enemy.cs
 * Last Edit: Toby Klauder, 9:09 AM, 5/19/2020
 * Description: handles pathfinding 
 * 
 */ 
public class enemy : MonoBehaviour
{
    // target, often end goal for the enemy 
    public Transform target;
    public float speed = 200f;
    //distance to next way point before making directional changes 
    public float nextwaypointdist = 3f;
    //path using Pathfinding consists of multiple waypoints 
    Path path;
    //current way point in the path that this enemy is on 
    int currentwaypoint = 0;
    //have we reached the end of the path? (passed all waypoints) 
    bool reachedend = false;
    //Seeker helps get around the obstacles, part of A* library 
    Seeker seeker;
    //Rigidbody used to apply forces
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        //grab the seeker component 
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete); 
    }

    void OnPathComplete(Path p) {
        //the path completed with no errors, then assign path and set currentwaypoint to 0 (at start of path) 
        if (!p.error) {
            path = p;
            currentwaypoint = 0; 
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if path does not exist, probably should not do the other stuff 
        if (path == null) {
            return; 
        }
        //if our currentwaypoint is beyond or equal to all the waypoints we have, we have reached the end, set this to true, return out
        if (currentwaypoint >= path.vectorPath.Count)
        {
            reachedend = true;
            return;
        }
        else { // if not, continue 
            reachedend = false; 
        }
        //direction that we should go, the currentwaypoint minus the rb.position, normalized, resulting in a vector towards a target 
        Vector2 direction = ((Vector2)path.vectorPath[currentwaypoint] - rb.position).normalized;
        //this is a debug statement, we will use Mathf.Round when rotating the bug sprite and playing appropriate animations 
        //Debug.Log("x: " + Mathf.Round(direction.x)  + " y: " + Mathf.Round(direction.y));
        //create force to direction times the speed and times Time.deltaTime so it is stable with changing framerates
        Vector2 force = direction * speed * Time.deltaTime;
        //apply the force so the bug actually moves 
        rb.AddForce(force);
        //get the distance to the current point 
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentwaypoint]);
        //if we are closer than the nextwaypointdist, start heading for the next waypoint 
        if (distance < nextwaypointdist) {
            currentwaypoint++; 
        }
    }
}
