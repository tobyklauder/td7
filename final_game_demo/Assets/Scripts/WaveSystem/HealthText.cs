using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthText : MonoBehaviour
{
    public Text healthText;
    private int health;

    public GameManager gameManager; 

    //public AudioClip loseSound;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health = GameManager.health;
        healthText.GetComponent<Text>().text = "Health: " + health;
        
        if(health == 0)
        {
            gameManager.loadGameLose();
        }
    }
}
