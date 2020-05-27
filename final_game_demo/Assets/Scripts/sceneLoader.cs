using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
