using Pathfinding;
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
    public static int money; 
    public Text onebuttontext;
    public Text twobuttontext;
    public Text towertypetext;
    public static string current = " ";
    public static string towertype = "";

    void Start()
    {
        upgradeSource.clip = upgradeSound;
        money = 500;
    }

    void Update()
    {
        //towertypetext.text = towertype;
        if (towertype == "poison") { //if tower type is poison (clicked on) 
            if (selected.GetComponent<poisontower>().pathone == 0) { // if on the first path then the first button should show the first upgrade 
                onebuttontext.text = "Double Range (75)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 1) { //if on the first path, second upgrade, then show the second upgrade 
                onebuttontext.text = "Double Range (150)"; 
            }
            if (selected.GetComponent<poisontower>().pathone == 2) { // "" 
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
            if (selected.GetComponent<basictower>().pathone == 0) {
                onebuttontext.text = "Increase Range (75)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 1) {
                onebuttontext.text = "Increase Range (150)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 2) {
                onebuttontext.text = "Increase Range (250)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 3) {
                onebuttontext.text = "Increase Range (300)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 4) {
                onebuttontext.text = "MAX LEVEL"; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 0) {
                twobuttontext.text = "Up Fire Rate (100)"; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 1) {
                twobuttontext.text = "Up Fire Rate (200)"; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 2) {
                twobuttontext.text = "Up Damage (300)"; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 3) {
                twobuttontext.text = "Up Damage (400)"; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 4) {
                twobuttontext.text = "MAX LEVEL"; 
            }
            
        }
        if (towertype == "fire") {
            if (selected.GetComponent<firetower>().pathone == 0) {
                onebuttontext.text = "Increase Range (75)"; 
            }
            if (selected.GetComponent<firetower>().pathone == 1) {
                onebuttontext.text = "Increase Range (150)"; 
            }
            if (selected.GetComponent<firetower>().pathone == 2) {
                onebuttontext.text = "Increase Range (250)"; 
            }
            if (selected.GetComponent<firetower>().pathone == 3) {
                onebuttontext.text = "Increase Range (300)"; 
            }
            if (selected.GetComponent<firetower>().pathone == 4) {
                onebuttontext.text = "MAX LEVEL"; 
            }
            if (selected.GetComponent<firetower>().pathtwo == 0) {
                twobuttontext.text = "+Energy Balls (100)"; 
            }
            if (selected.GetComponent<firetower>().pathtwo == 1) {
                twobuttontext.text = "+Energy Balls (200)"; 
            }
            if (selected.GetComponent<firetower>().pathtwo == 2) {
                twobuttontext.text = "+Energy Balls (300)"; 
            }
            if (selected.GetComponent<firetower>().pathtwo == 3) {
                twobuttontext.text = "+Energy Balls (400)"; 
            }
            if (selected.GetComponent<firetower>().pathtwo == 4) {
                twobuttontext.text = "MAX LEVEL"; 
            }
        }
        
    }

    public void click() { // this script is attached to the top button and is invoked when the button is clicked 
        if(towertype == "poison")
        {
            if (selected.GetComponent<poisontower>().pathone == 0) {
                if (money >= 75)
                {
                    money -= 75;
                    selected.GetComponent<poisontower>().radius += 1;
                    selected.GetComponent<poisontower>().pathone++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<poisontower>().pathone == 1) {
                if (money >= 150)
                {
                    money -= 150;
                    selected.GetComponent<poisontower>().radius += 2;
                    selected.GetComponent<poisontower>().pathone++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<poisontower>().pathone == 2) {
                if (money >= 400)
                {
                    money -= 400;
                    selected.GetComponent<poisontower>().radius += 1;
                    selected.GetComponent<poisontower>().slowenemy = true;
                    selected.GetComponent<poisontower>().pathone++;
                    upgradeSource.Play(); 
                    return;
                }
                
            }
            if (selected.GetComponent<poisontower>().pathone == 3) {
                if (money >= 500)
                {
                    money -= 500;
                    selected.GetComponent<poisontower>().radius += 2;
                    selected.GetComponent<poisontower>().pathone++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
        }
        if (towertype == "basic") {
            if (selected.GetComponent<basictower>().pathone == 0) {
                if (money >= 75)
                {
                    money -= 75;
                    selected.GetComponent<basictower>().range += 1;
                    selected.GetComponent<basictower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<basictower>().pathone == 1) {
                if (money >= 150)
                {
                    money -= 150;
                    selected.GetComponent<basictower>().range += 1;
                    selected.GetComponent<basictower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
            if (selected.GetComponent<basictower>().pathone == 2) {
                if (money >= 250)
                {
                    money -= 250;
                    selected.GetComponent<basictower>().range += 1;
                    selected.GetComponent<basictower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
            if (selected.GetComponent<basictower>().pathone == 3) {
                if (money >= 300)
                {
                    money -= 300;
                    selected.GetComponent<basictower>().range += 1;
                    selected.GetComponent<basictower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
        }
        if (towertype == "fire") {
            if (selected.GetComponent<firetower>().pathone == 0)
            {
                if (money >= 75)
                {
                    money -= 75;
                    selected.GetComponent<firetower>().range += 1;
                    selected.GetComponent<firetower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathone == 1)
            {
                if (money >= 150)
                {
                    money -= 150;
                    selected.GetComponent<firetower>().range += 1;
                    selected.GetComponent<firetower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathone == 2)
            {
                if (money >= 250)
                {
                    money -= 250;
                    selected.GetComponent<firetower>().range += 1;
                    selected.GetComponent<firetower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathone == 3)
            {
                if (money >= 300)
                {
                    money -= 300;
                    selected.GetComponent<firetower>().range += 1;
                    selected.GetComponent<firetower>().pathone++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
        }
    }

    public void clicktwo() { 
        if (towertype == "poison") {
            if (selected.GetComponent<poisontower>().pathtwo == 0) {
                if (money >= 100)
                {
                    selected.GetComponent<poisontower>().damage += 0.002f;
                    money -= 100;
                    selected.GetComponent<poisontower>().pathtwo++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<poisontower>().pathtwo == 1) {
                if (money >= 200)
                {
                    selected.GetComponent<poisontower>().damage += 0.002f;
                    money -= 200;
                    selected.GetComponent<poisontower>().pathtwo++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<poisontower>().pathtwo == 2) {
                if (money >= 300)
                {
                    selected.GetComponent<poisontower>().damage += 0.002f;
                    money -= 300;
                    selected.GetComponent<poisontower>().pathtwo++;
                    upgradeSource.Play(); 
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<poisontower>().pathtwo == 3) {
                if (money >= 400)
                {
                    selected.GetComponent<poisontower>().damage += 0.002f;
                    money -= 400;
                    selected.GetComponent<poisontower>().pathtwo++;
                    upgradeSource.Play(); 
                    return;
                }
                else return;
            }
        }
        if (towertype == "basic") {
            if (selected.GetComponent<basictower>().pathtwo == 0) {
                if (money >= 100)
                {
                    money -= 100; 
                    selected.GetComponent<basictower>().firerate -= 0.5f;
                    selected.GetComponent<basictower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 1) {
                if (money >= 200)
                {
                    money -= 200; 
                    selected.GetComponent<basictower>().firerate -= 0.5f;
                    selected.GetComponent<basictower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 2) {
                if (money >= 300)
                {
                    money -= 300; 
                    selected.GetComponent<basictower>().firerate -= 0.5f;
                    selected.GetComponent<basictower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 3) {
                if (money >= 400)
                {
                    money -= 400; 
                    selected.GetComponent<basictower>().firerate -= 0.5f;
                    selected.GetComponent<basictower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return; 
            }
        }
        if (towertype == "fire") {
            if (selected.GetComponent<firetower>().pathtwo == 0)
            {
                if (money >= 100)
                {
                    money -= 100;
                    selected.GetComponent<firetower>().burstBulletCount++;
                    selected.GetComponent<firetower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathtwo == 1)
            {
                if (money >= 200)
                {
                    money -= 200;
                    selected.GetComponent<firetower>().burstBulletCount++;
                    selected.GetComponent<firetower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathtwo == 2)
            {
                if (money >= 300)
                {
                    money -= 300;
                    selected.GetComponent<firetower>().burstBulletCount++;
                    selected.GetComponent<firetower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
                    return;
            }
            if (selected.GetComponent<firetower>().pathtwo == 3)
            {
                if (money >= 400)
                {
                    money -= 400;
                    selected.GetComponent<firetower>().burstBulletCount++;
                    selected.GetComponent<firetower>().pathtwo++;
                    upgradeSource.Play();
                    return;
                }
                else
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
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadGameLose()
    {
        SceneManager.LoadScene("GameLose");
    }

    public void loadGameWin()
    {
        SceneManager.LoadScene("GameWin");
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}

