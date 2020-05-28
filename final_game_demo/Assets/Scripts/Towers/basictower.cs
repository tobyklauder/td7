using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float timer;
    public int firerate = 0;
    public int direction = 0;
    public SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>(); 
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > firerate) {
            bulletshoot = Instantiate(bullet, transform.position, transform.rotation);
            Vector2 dir = new Vector2(0, 0);
            if (direction == 0) {
                dir = Vector2.left;
                Debug.Log("shoot left");
                render.sprite = west; 
            }
            if (direction == 1) {
                Debug.Log("shoot NW");
                dir = new Vector2(-0.5f, 0.5f);
                render.sprite = northwest; 
            }
            if (direction == 2) {
                Debug.Log("shoot up"); 
                dir = Vector2.up;
                render.sprite = north; 
            }
            if (direction == 3) {
                Debug.Log("shoot NE");
                dir = new Vector2(0.5f, 0.5f);
                render.sprite = northeast; 
            }
            if (direction == 4) {
                Debug.Log("shoot right");
                dir = Vector2.right;
                render.sprite = east; 
            }
            if (direction == 5) {
                Debug.Log("shoot SE");
                dir = new Vector2(0.5f, -0.5f);
                render.sprite = southeast; 
            }
            if (direction == 6) {
                Debug.Log("shoot down");
                dir = Vector2.down;
                render.sprite = south; 
            }
            if (direction == 7) {
                Debug.Log("shoot SW");
                dir = new Vector2(-0.5f, -0.5f);
                render.sprite = southwest; 
            }
            bulletshoot.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
            timer = 0; 
        }
    }

    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject;
        GameManager.towertype = "basic";
    }
}
