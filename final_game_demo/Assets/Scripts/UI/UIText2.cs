using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText2 : MonoBehaviour
{

    public void WaveCount()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Wave: " + FindObjectOfType<EnemySpawnerScript>().WaveCounter.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaveCount();
    }
}
