using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    //float randX;
    //float randY;
    Vector2 whereToSpawn;
    public float WaveCounter;
    public int WaveMax;
    public int EnemyCounter;
    int i;
    int p1;
    int p2;
    int p3;
    //public float x1;
    //public float x2;
    //public float y1;
    //public float y2;

    // Start is called before the first frame update
    void Start()
    {
        //SET IT SO THAT THIS ALL STARTS IF THE PLAYER CLICKS A BUTTON
        WaveCounter = 0;
        WaveMax = 20;
        WaveSystem();
        p3 = 3;
        p2 = 2;
        p1 = 3;
    }

    void WaveSystem()
    {

        if (WaveCounter <= 20)
        {
            whereToSpawn = new Vector2(-11, 4);

            if (WaveCounter <= 6)
            {
                for (i = 0; i < p3; i++)
                {
                    Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                }
                p3 += 3;
            }

            else if (WaveCounter <= 12)
            {
                if (WaveCounter == 7)
                {
                    for (i = 0; i < p1; i++)
                    {
                        Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
                    }
                }
                else if (WaveCounter > 7 && WaveCounter <= 12)
                {
                    for (i = 0; i <= p1; i++)
                    {
                        Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
                    }
                    p1 += 1;

                    for (i = 0; i < p2; i++)
                    {
                        Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                    }
                    p2 += 2;
                }
            }

            else if (WaveCounter <= 18)
            {
                if (WaveCounter == 13)
                {
                    for (i = 0; i < p1; i++)
                    {
                        Instantiate(Enemy3, whereToSpawn, Quaternion.identity);
                    }
                    p1 += 1;
                }
                if (WaveCounter == 14)
                {
                    for (i = 0; i < p1; i++)
                    {
                        Instantiate(Enemy3, whereToSpawn, Quaternion.identity);
                    }
                    p1 += 1;
                    Debug.Log(p1);

                    for (i = 0; i < p2; i++)
                    {
                        Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
                    }
                    p2 += 2;
                }
                else if (WaveCounter > 14)
                {
                    for (i = 0; i <= p1 - 1; i++)
                    {
                        Instantiate(Enemy3, whereToSpawn, Quaternion.identity);
                    }
                    p1 += 1;
                    Debug.Log(p1);

                    //Enemy 2 increases by2 each time
                    for (i = 0; i < p2; i++)
                    {
                        Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
                    }
                    p2 += 2;

                    if (WaveCounter >= 15)
                    {
                        for (i = 0; i < p3; i++)
                        {
                            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                        }
                        p3 += 3;
                    }
                }
            }
            else if (WaveCounter <= 20)
            {
                Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
            }

            //Instantiate(Enemy, whereToSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Set an enemy counter to determine when to start next wave
        EnemyCounter = GameObject.FindObjectsOfType<enemy>().Length;
        if (WaveCounter >= 21)
        {
            SceneManager.LoadScene(0);
        }

        else if (EnemyCounter == 0)
        {
            WaveCounter++;
            WaveSystem();

            if (WaveCounter == 12)
            {
                p3 = 3;
                p1 = 3;
                p2 = 2;
            }
        }
    }
}
