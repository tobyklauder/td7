using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisontower : MonoBehaviour
{
    public GameObject spawn; 
    public Collider2D[] colliders; 
    public int radius = 2;
    public bool slowenemy;
    public float damage = 0.01f;
    public int view = 0; 
    public int pathone = 0;
    public int pathtwo = 0;

    public AudioSource audioSource;
    public AudioClip towerShoot;
    public AudioClip towerPlace;
    public Animator anim;

    private bool inRange;

    private void Start()
    {
        audioSource.clip = towerPlace;
        audioSource.Play();
        inRange = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
        inRange = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "enemy")
                {
                    colliders[i].gameObject.GetComponent<enemy>().health -= damage;
                    Debug.Log("taking health");
                    inRange = true;
                }
            }
        }
        if(inRange == false)
        {
            anim.SetBool("IsShoot", false);
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.clip = towerShoot;
            audioSource.Play();
            anim.SetBool("IsShoot", true);
        }
    }

    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject; 
        GameManager.towertype = "poison"; 
    }
}
