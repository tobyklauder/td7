using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<musicManager>().playMenuTheme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
