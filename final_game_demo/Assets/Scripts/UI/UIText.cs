using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    public void enemyCount()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Enemies Left: " + FindObjectOfType<EnemySpawnerScript>().EnemyCounter.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount();
    }
}
