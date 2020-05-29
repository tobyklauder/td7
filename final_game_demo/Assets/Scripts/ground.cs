using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class ground : MonoBehaviour
{
    public GameObject poision;
    public GameObject basic;
    public GameObject fire; 
    public bool plantable;
    public bool tooclose; 
    Vector2 mousepos;
    Collider2D[] collider; 
    Vector3 mouseposscreen;
    // Update is called once per frame
    void Update()
    {
        mouseposscreen = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mouseposscreen.z += 10;
    }

    private void OnMouseEnter()
    {
        plantable = true; 
    }

    private void OnMouseExit()
    {
        plantable = false; 
    }

    private void OnMouseDown()
    {
        print("Mouse down");
        if (plantable) {
            if (GameManager.current == "poison")
            {
                if (GameManager.money >= 300)
                {
                    GameManager.money -= 300;
                    Instantiate(poision, mouseposscreen, transform.rotation);
                    GameManager.current = "";
                }
                else
                    return;
            }
            else if (GameManager.current == "basic")
            {
                if (GameManager.money >= 100)
                {
                    GameManager.money -= 100;
                    Instantiate(basic, mouseposscreen, transform.rotation);
                    GameManager.current = "";
                }
                else
                    return;
            }
            else if (GameManager.current == "fire") {
                if (GameManager.money >= 200)
                {
                    GameManager.money -= 200;
                    print("Instantiating a fire tower");
                    Instantiate(fire, mouseposscreen, transform.rotation);
                    GameManager.current = "";
                }
                else
                    return;
            }
        }
    }
}
