using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameTheme;
    public AudioClip menuTheme;
    public AudioClip loseSound;
    public AudioClip winSound;

    public void playGameTheme()
    {
        audioSource.clip = gameTheme;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void playMenuTheme()
    {
        audioSource.clip = menuTheme;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void playLoseSound()
    {
        audioSource.clip = loseSound;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void playWinSound()
    {
        audioSource.clip = winSound;
        audioSource.loop = false;
        audioSource.Play();
    }
}
