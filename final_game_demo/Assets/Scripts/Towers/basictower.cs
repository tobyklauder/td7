using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;

public class basictower : MonoBehaviour
{
    public Sprite west;
    public Sprite northwest;
    public Sprite north;
    public Sprite northeast;
    public Sprite east;
    public Sprite southeast;
    public Sprite south;
    public Sprite southwest;
    public GameObject bullet; //bullet prefab 
    public float bulletSpeed;
    public GameObject bulletshoot;
    public Collider2D[] colliders; 
    public float timer;
    public int firerate = 0;
    public int direction = 0;
    public SpriteRenderer render;
    public GameObject enemy;
    public Vector2 dir;
    public int pathone;
    public int pathtwo; 
    public AudioSource audioSource;
    public AudioClip towerShoot;
    public AudioClip towerPlace;
    public int range = 5;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        audioSource.clip = towerPlace;
        audioSource.Play();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
    // Update is called once per frame
    void Update()
    {
       Vector3 offset;
        if (enemy == null)
        {
            colliders = Physics2D.OverlapCircleAll(this.transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "enemy")
                {
                    enemy = colliders[i].gameObject;
                }
            }
        }
        else {
            dir = (enemy.transform.position - this.transform.position).normalized;
            //Debug.Log(dir); 
            Debug.DrawRay(this.transform.position, enemy.gameObject.transform.position - this.transform.position, Color.blue);
        }
        try
        {
            if (Vector2.Distance(enemy.transform.position, this.gameObject.transform.position) > 5)
            {
                enemy = null;
            }
        } catch (Exception UnsignedReferenceException) {
            return;     
        }
        timer += Time.deltaTime;
            if ((dir.x < 0.75 && dir.x > 0.25) && (dir.y < 0.75 && dir.y > 0.25)) {
                dir = new Vector2(0.5f, 0.5f); //shoot NE 
                render.sprite = northeast; 
            }
            if ((dir.x < 0 && dir.x > -0.75) && (dir.y < 0 && dir.y > -0.75)) {
                dir = new Vector2(-0.5f, -0.5f); //shoot SW
                render.sprite = southwest;
            }
            if ((dir.x < -0.75 && dir.x > -1.25) && (dir.y < 0.25 && dir.y > -0.25)) {
                dir = new Vector2(-1f, 0f); //shoot left
                render.sprite = west; 
            }
            if ((dir.x > 0.75 && dir.x < 1.25) && (dir.y < 0.25 && dir.y > -0.25)) {
                dir = new Vector2(1f, 0f); //shoot right 
                render.sprite = east; 
            }
            if ((dir.x < 0.25 && dir.x > -0.25) && (dir.y < 1.25 && dir.y > 0.75)) {
                dir = new Vector2(0f, 1f); //shoot up 
                render.sprite = north; 
            }
            if ((dir.x < 0.25 && dir.x > -0.25) && (dir.y > -1.25 && dir.y < -0.75)) {
                dir = new Vector2(0f, -1f); //shoot down 
                render.sprite = south; 
            }
            if ((dir.x < 0.75 && dir.x > 0.25) && (dir.y < 0 && dir.y > -0.75)) {
                dir = new Vector2(0.5f, -0.5f);
                render.sprite = southeast; 
            }
            if ((dir.x < 0 && dir.x > -0.75) && (dir.y < 0.75 && dir.y > 0.25)) {
                dir = new Vector2(-0.5f, 0.5f);
                render.sprite = northwest; 
            }

        // if (direction == 0) {
        //    dir = Vector2.left;
        //   Debug.Log("shoot left");
        //  render.sprite = west; 
        // }
        //if (direction == 1) {
        //   Debug.Log("shoot NW");
        //  dir = new Vector2(-0.5f, 0.5f);
        //  render.sprite = northwest; 
        // }
        // if (direction == 2) {
        //    Debug.Log("shoot up"); 
        //   dir = Vector2.up;
        //  render.sprite = north; 
        //}
        //  if (direction == 3) {
        //    Debug.Log("shoot NE");
        //  dir = new Vector2(0.5f, 0.5f);
        // render.sprite = northeast; 
        // }
        // if (direction == 4) {
        //   Debug.Log("shoot right");
        //  dir = Vector2.right;
        // render.sprite = east; 
        //}
        //if (direction == 5) {
        //   Debug.Log("shoot SE");
        //  dir = new Vector2(0.5f, -0.5f);
        // render.sprite = southeast; 
        //}
        //if (direction == 6) {
        //   Debug.Log("shoot down");
        //  dir = Vector2.down;
        // render.sprite = south; 
        // }
        //  if (direction == 7) {
        //    Debug.Log("shoot SW");
        //  dir = new Vector2(-0.5f, -0.5f);
        // render.sprite = southwest; 
        //}
        if (timer > firerate)
        {
            //Vector3 relativePos = enemy.transform.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            bulletshoot = Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
            bulletshoot.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
            audioSource.clip = towerShoot;
            audioSource.Play();
            timer = 0;
        }
  }
    

    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject;
        GameManager.towertype = "basic";
    }
}

