using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basictower : MonoBehaviour
{
    public int radius = 5;
    public bool slowenemy;
    public int damage;
    public int view = 0; 
    public int pathone = 0;
    public int pathtwo = 0; 
    private void Update()
    {

    }

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject; 
        Debug.Log("clicked");
        GameManager.towertype = "basic"; 
    }
}
