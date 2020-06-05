using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthText : MonoBehaviour
{
    public Text healthText;
    private int health;


    //public AudioClip loseSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = GameManager.health;
        healthText.GetComponent<Text>().text = "Health: " + health;
      
    }
}
