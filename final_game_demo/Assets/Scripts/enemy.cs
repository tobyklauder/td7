using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
using System;
/* enemy.cs
* Last Edit: Toby Klauder, 9:09 AM, 5/19/2020
* Description: handles pathfinding 
* 
*/
public class enemy : MonoBehaviour
{
    public Animator anim;
    public Sprite left;
    public Sprite right;
    public Sprite down;
    public Sprite up;
    public SpriteRenderer render; 
    public float health = 5f;
    public int mon;
    // target, often end goal for the enemy 
    public Transform target;
    public float speed = 200f;
    //distance to next way point before making directional changes 
    public float nextwaypointdist = 1f;
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
    //Variables to handle firetower fire
    public float timeOnFire;
    private float timer;
    private bool onFire;
    public float fireDPS;
    public bool moneyadd; 
    public bool isDead;


    int DirCheck;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        //grab the seeker component 
        anim = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>(); 

        seeker.StartPath(rb.position, target.position, OnPathComplete);

        timer = timeOnFire;
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
        if (health <= 0) {
            if (!moneyadd)
            {
                GameManager.money += mon;
                moneyadd = true; 
            }
        }
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
        if (Mathf.Round(direction.x) == 0 && Mathf.Round(direction.y) == 1)
        {
            DirCheck = 1;
            //SPAGHETTI CODE WILL FIX SOON -EY
            anim.SetBool("Move4", false);
            anim.SetBool("Move2", false);
            anim.SetBool("Move3", false);

            anim.SetBool("Move", true);
            //render.sprite = up; 
        }
        else if (Mathf.Round(direction.x) == 0 && Mathf.Round(direction.y) == -1)
        {
            DirCheck = 2;
            //SPAGHETTI CODE WILL FIX SOON -EY
            anim.SetBool("Move", false);
            anim.SetBool("Move4", false);
            anim.SetBool("Move2", false);

            anim.SetBool("Move3", true);
            //render.sprite = down; 
        }
        else if (Mathf.Round(direction.x) == -1 && Mathf.Round(direction.y) == 0)
        {
            DirCheck = 3;
            //SPAGHETTI CODE WILL FIX SOON -EY
            anim.SetBool("Move", false);
            anim.SetBool("Move2", false);
            anim.SetBool("Move3", false);

            anim.SetBool("Move4", true);
            //render.sprite = left; 
        }
        else if (Mathf.Round(direction.x) == 1 && Mathf.Round(direction.y) == 0)
        {
            DirCheck = 4;
            //SPAGHETTI CODE WILL FIX SOON -EY
            anim.SetBool("Move3", false);
            anim.SetBool("Move", false);
            anim.SetBool("Move4", false);

            anim.SetBool("Move2", true);
            //render.sprite = right; 
        }
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
    
    private void Update()
    {
        if (health <= 0)
        {
            if (DirCheck == 1)
            {
                Destroy(this.gameObject, 0.5f);
                anim.Play("JumboDeathUp");
                anim.Play("JuggerDeathUp");
                anim.Play("JumperDeathUp");
            }
            else if (DirCheck == 2)
            {
                Destroy(this.gameObject, 0.5f);
                anim.Play("JumboDeathDown");
                anim.Play("JuggerDeathDown");
                anim.Play("JumperDeathDown");
            }
            else if (DirCheck == 3)
            {
                Destroy(this.gameObject, 0.5f);
                anim.Play("JumboDeathLeft");
                anim.Play("JuggerDeathLeft");
                anim.Play("JumperDeathLeft");
            }
            else if (DirCheck == 4)
            {
                Destroy(this.gameObject, 0.5f); 
                anim.Play("JumboDeathRight");
                anim.Play("JuggerDeathRight");
                anim.Play("JumperDeathRight");
            }
        }
        if (onFire)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                onFire = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                health -= fireDPS*Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<fireball>() != null)
        {
            Destroy(collision.gameObject);
            onFire = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            health -= 0.05f;
        }
        else if (collision.gameObject.tag == "bullet") {
            Destroy(collision.gameObject);
            health -= 1f; 
        }
        if (collision.gameObject.tag == "Finish") {
            GameManager.health--;
            Debug.Log("enemy arrived, siphoning health"); 
        }
    }
}
