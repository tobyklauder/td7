﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static AudioSource audioSource;
    public AudioSource upgradeSource;
    public AudioClip upgradeSound;
    public static int health = 10;
    public static GameObject selected; 
    public int money = 500; 
    public Text onebuttontext;
    public Text twobuttontext;
    public Text towertypetext;
    public static string current = " ";
    public static string towertype = "";

    void Start()
    {
        upgradeSource.clip = upgradeSound;
    }

    void Update()
    {
        towertypetext.text = towertype;
        if (towertype == "poison") {
            if (selected.GetComponent<poisontower>().pathone == 0) {
                onebuttontext.text = "Double Range (75)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 1) {
                onebuttontext.text = "Double Range (150)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 2) {
                onebuttontext.text = "Slow Bugs 1/4 (400)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 3) {
                onebuttontext.text = "Up Range, Slow (500)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 4) {
                onebuttontext.text = "MAX LEVEL"; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 0) {
                twobuttontext.text = "Increase Damage (100)"; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 1) {
                twobuttontext.text = "Increase Damage (200)";
            }
            if (selected.GetComponent<poisontower>().pathtwo == 2) {
                twobuttontext.text = "Increase Damage (300)"; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 3) {
                twobuttontext.text = "Increase Damage (400)"; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 4) {
                twobuttontext.text = "MAX LEVEL"; 
            }
        }
        if (towertype == "basic") {
            if (selected.GetComponent<basictower>().direction == 8) {
                selected.GetComponent<basictower>().direction = 0; 
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log(selected.GetComponent<basictower>().direction);
                selected.GetComponent<basictower>().direction += 1;
                Debug.Log(selected.GetComponent<basictower>().direction); 
                
            }
            
        }
        
    }

    public void click() {
        if (selected.GetComponent<poisontower>().pathone != 4)
        {
            upgradeSource.Play();
        }
        if(towertype == "poison")
        {
            if (selected.GetComponent<poisontower>().pathone == 0) {
                selected.GetComponent<poisontower>().radius += 1;
                money -= 500;
                selected.GetComponent<poisontower>().pathone++;
                return; 
            }
            if (selected.GetComponent<poisontower>().pathone == 1) {
                selected.GetComponent<poisontower>().radius += 2;
                money -= 1250;
                selected.GetComponent<poisontower>().pathone++;
                return; 
            }
            if (selected.GetComponent<poisontower>().pathone == 2) {
                selected.GetComponent<poisontower>().radius += 1;
                selected.GetComponent<poisontower>().slowenemy = true; 
                money -= 1750;
                selected.GetComponent<poisontower>().pathone++;
                return; 
            }
            if (selected.GetComponent<poisontower>().pathone == 3) {
                selected.GetComponent<poisontower>().radius += 2;
                money -= 2500;
                selected.GetComponent<poisontower>().pathone++;
                return; 
            }
        }
    }

    public void clicktwo() {
        if (selected.GetComponent<poisontower>().pathtwo != 4)
        {
            upgradeSource.Play();
        }
        if (towertype == "poison") {
            if (selected.GetComponent<poisontower>().pathtwo == 0) {
                selected.GetComponent<poisontower>().damage += 0.01f;
                money -= 100;
                selected.GetComponent<poisontower>().pathtwo++; 
                return; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 1) {
                selected.GetComponent<poisontower>().damage += 0.02f;
                money -= 200;
                selected.GetComponent<poisontower>().pathtwo++; 
                return; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 2) {
                selected.GetComponent<poisontower>().damage += 0.01f;
                money -= 300;
                selected.GetComponent<poisontower>().pathtwo++; 
                return; 
            }
            if (selected.GetComponent<poisontower>().pathtwo == 3) {
                selected.GetComponent<poisontower>().damage += 0.02f;
                money -= 400;
                selected.GetComponent<poisontower>().pathtwo++; 
                return; 
            }
        }
    }

    public void enablebasic() {
        current = "basic"; 
    }
    public void enablepoison() {
        current = "poison"; 
    }
    public void enablefire()
    {
        current = "fire";
    }

    public void loadGame()
    {
        SceneManager.LoadScene("MainGame");
        GetComponent<musicManager>().playGameTheme();
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GetComponent<musicManager>().playMenuTheme();
    }

    public void loadGameLose()
    {
        SceneManager.LoadScene("GameLose");
        GetComponent<musicManager>().playLoseSound();
    }

    public void loadGameWin()
    {
        SceneManager.LoadScene("GameWin");
        GetComponent<musicManager>().playWinSound();
    }

}

