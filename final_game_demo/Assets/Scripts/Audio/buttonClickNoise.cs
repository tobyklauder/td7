using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClickNoise : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickNoise;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clickNoise;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        audioSource.Play();
    }
}
