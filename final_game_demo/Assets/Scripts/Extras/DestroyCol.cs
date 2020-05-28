using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCol : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip loseLifeClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<Canvas>().GetComponent<AudioSource>(); 
        audioSource.clip = loseLifeClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            audioSource.Play();
            GameManager.health -= 1;
            Destroy(this.gameObject);
        }   
    }
}
