using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GameManager : MonoBehaviour
{
    public static GameObject selected; 
    public int money = 500; 
    public Text onebuttontext;
    public Text twobuttontext;
    public Text towertypetext;
    public static string current = "basic";
    public static string towertype = "";

    void Update()
    {
        towertypetext.text = towertype;
        if (towertype == "basic") {
            if (selected.GetComponent<basictower>().pathone == 0) {
                onebuttontext.text = "Double Range (75)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 1) {
                onebuttontext.text = "Double Range (150)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 2) {
                onebuttontext.text = "Slow Bugs 1/4 (400)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 3) {
                onebuttontext.text = "Up Range, Slow (500)"; 
            }
            if (selected.GetComponent<basictower>().pathone == 4) {
                onebuttontext.text = "MAX LEVEL"; 
            }
        }
        
    }

    public void click() { 
        if(towertype == "basic")
        {
            if (selected.GetComponent<basictower>().pathone == 0) {
                selected.GetComponent<basictower>().radius += 5;
                money -= 500;
                selected.GetComponent<basictower>().pathone++;
                return; 
            }
            if (selected.GetComponent<basictower>().pathone == 1) {
                selected.GetComponent<basictower>().radius += 10;
                money -= 1250;
                selected.GetComponent<basictower>().pathone++;
                return; 
            }
            if (selected.GetComponent<basictower>().pathone == 2) {
                selected.GetComponent<basictower>().radius += 15;
                selected.GetComponent<basictower>().slowenemy = true; 
                money -= 1750;
                selected.GetComponent<basictower>().pathone++;
                return; 
            }
            if (selected.GetComponent<basictower>().pathone == 3) {
                selected.GetComponent<basictower>().radius += 20;
                money -= 2500;
                selected.GetComponent<basictower>().pathone++;
                return; 
            }
        }
    }

    public void clicktwo() {
        if (towertype == "basic") {
            if (selected.GetComponent<basictower>().pathtwo == 0) {
                return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 1) {
                return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 2) {
                return; 
            }
            if (selected.GetComponent<basictower>().pathtwo == 3) {
                return; 
            }
        }
    }
}

