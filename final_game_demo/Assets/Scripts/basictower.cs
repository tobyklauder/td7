using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basictower : MonoBehaviour
{
    public GameObject bullet; //bullet prefab 
    public float bulletSpeed;
    public GameObject bulletshoot;
    public float timer;
    public int firerate = 5;
    public double direction = 0;

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
            }
            if (direction == 1) {
                Debug.Log("shoot up");
                dir = Vector2.up; 
            }
            if (direction == 2) {
                Debug.Log("shoot right"); 
                dir = Vector2.right;
            }
            if (direction == 3) {
                Debug.Log("shoot down");
                dir = Vector2.down; 
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
