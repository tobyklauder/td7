using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
