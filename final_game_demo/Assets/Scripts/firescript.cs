using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firescript : MonoBehaviour
{
    public float timeOnFire;
    private float timer;
    private bool onFire;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeOnFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                onFire = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<fireball>() != null)
        {
            print("Setting on fire");
            onFire = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
