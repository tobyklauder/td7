using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;

public class firetower : MonoBehaviour
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
    public int burstBulletCount = 3;
    private int currentBurstBulletCount = 0;
    public float coolDownTime = 1;
    private float currentCoolDownTime = 0;
    private bool onCooldown = false;
    public int direction = 0;
    public SpriteRenderer render;
    public GameObject enemy;
    public Vector2 dir;

    public AudioSource audioSource;
    public AudioClip towerShoot;
    public AudioClip towerPlace;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        audioSource.clip = towerPlace;
        audioSource.Play();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 offset;
        if (enemy == null)
        {
            colliders = Physics2D.OverlapCircleAll(this.transform.position, 5f);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "enemy")
                {
                    enemy = colliders[i].gameObject;
                }
            }
        }
        else
        {
            dir = (enemy.transform.position - this.transform.position).normalized;
            //Debug.Log(dir);
            Debug.DrawRay(this.transform.position, enemy.gameObject.transform.position - this.transform.position, Color.blue);
        }
        if (Vector2.Distance(enemy.transform.position, this.gameObject.transform.position) > 5)
        {
            enemy = null;
        }
        timer += Time.deltaTime;
        if ((dir.x < 0.75 && dir.x > 0.25) && (dir.y < 0.75 && dir.y > 0.25))
        {
            dir = new Vector2(0.5f, 0.5f); //shoot NE 
            render.sprite = northeast;
        }
        if ((dir.x < 0 && dir.x > -0.75) && (dir.y < 0 && dir.y > -0.75))
        {
            dir = new Vector2(-0.5f, -0.5f); //shoot SW
            render.sprite = southwest;
        }
        if ((dir.x < -0.75 && dir.x > -1.25) && (dir.y < 0.25 && dir.y > -0.25))
        {
            dir = new Vector2(-1f, 0f); //shoot left
            render.sprite = west;
        }
        if ((dir.x > 0.75 && dir.x < 1.25) && (dir.y < 0.25 && dir.y > -0.25))
        {
            dir = new Vector2(1f, 0f); //shoot right 
            render.sprite = east;
        }
        if ((dir.x < 0.25 && dir.x > -0.25) && (dir.y < 1.25 && dir.y > 0.75))
        {
            dir = new Vector2(0f, 1f); //shoot up 
            render.sprite = north;
        }
        if ((dir.x < 0.25 && dir.x > -0.25) && (dir.y > -1.25 && dir.y < -0.75))
        {
            dir = new Vector2(0f, -1f); //shoot down 
            render.sprite = south;
        }
        if ((dir.x < 0.75 && dir.x > 0.25) && (dir.y < 0 && dir.y > -0.75))
        {
            dir = new Vector2(0.5f, -0.5f);
            render.sprite = southeast;
        }
        if ((dir.x < 0 && dir.x > -0.75) && (dir.y < 0.75 && dir.y > 0.25))
        {
            dir = new Vector2(-0.5f, 0.5f);
            render.sprite = northwest;
        }
        //if it's time for the next projectile to be shot
        if (timer > firerate)
        {
            
            //then as long as the tower isn't on cooldown
            if (!onCooldown)
            {
                //create and shoot the bullet + play the sound effect
                bulletshoot = Instantiate(bullet, transform.position, transform.rotation);
                bulletshoot.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
                audioSource.clip = towerShoot;
                audioSource.Play();
                timer = 0;
                currentBurstBulletCount--;
                //if that was the last shot in the current burst
                if(currentBurstBulletCount <= 0)
                {
                    //then turn cooldown on and set the cooldown timer to the length of a cooldown
                    onCooldown = true;
                    currentCoolDownTime = coolDownTime;
                }
            }
        }
        //if the tower is on cooldown
        if (onCooldown && currentCoolDownTime <= 0)
        {
            //if it is at the end of its cooldown
            if (currentCoolDownTime <= 0)
            {
                //then turn cooldown off and fill the burst bullet count to the total in a burst
                onCooldown = false;
                currentBurstBulletCount = burstBulletCount;
            }
            //otherwise it is still on cooldown
            else
            {
                //so tick the cooldown timer down
                currentCoolDownTime -= Time.deltaTime;
            }
        }
    }


    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject;
        GameManager.towertype = "basic";
    }
}

