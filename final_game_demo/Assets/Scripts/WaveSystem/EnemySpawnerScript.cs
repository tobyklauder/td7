using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    Vector2 whereToSpawn;
    public float WaveCounter;
    public int WaveMax;
    public int EnemyCounter;
    public float EStag;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    int i;
    int p1;
    int p2;
    int p3;
    public AudioSource audioSource;
    public AudioClip waveStart;

    // Start is called before the first frame update
    void Start()
    {
        WaveMax = 20;
        WaveSystem();
        p3 = 3;
        p2 = 2;
        p1 = 3;
        audioSource.clip = waveStart;
    }

    void spawnEnemy(int type)
    {
        if (type == 1)
        {
            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
        }
        else if (type == 2)
        {
            Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemy3, whereToSpawn, Quaternion.identity);
        }
    }

    IEnumerator WaveSystem()
    {
        if (WaveCounter <= 20)
        {
            whereToSpawn = new Vector2(-11, 4);

            if (WaveCounter <= 6)
            {
                for (i = 0; i < p3; i++)
                {
                    spawnEnemy(1);
                    yield return new WaitForSeconds(EStag);
                }
                p3 += 3;
            }

            else if (WaveCounter <= 12)
            {
                if (WaveCounter == 7)
                {
                    for (i = 0; i < p1; i++)
                    {
                        spawnEnemy(2);
                        yield return new WaitForSeconds(EStag);
                    }
                }
                else if (WaveCounter > 7 && WaveCounter <= 12)
                {
                    for (i = 0; i <= p1; i++)
                    {
                        spawnEnemy(2);
                        yield return new WaitForSeconds(EStag);
                    }
                    p1 += 1;

                    for (i = 0; i < p2; i++)
                    {
                        spawnEnemy(1);
                        yield return new WaitForSeconds(EStag);
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
                        spawnEnemy(3);
                        yield return new WaitForSeconds(EStag);
                    }
                    p1 += 1;
                }
                if (WaveCounter == 14)
                {
                    for (i = 0; i < p1; i++)
                    {
                        spawnEnemy(3);
                        yield return new WaitForSeconds(EStag);
                    }
                    p1 += 1;
                    Debug.Log(p1);

                    for (i = 0; i < p2; i++)
                    {
                        spawnEnemy(2);
                        yield return new WaitForSeconds(EStag);
                    }
                    p2 += 2;
                }
                else if (WaveCounter > 14)
                {
                    for (i = 0; i <= p1 - 1; i++)
                    {
                        spawnEnemy(3);
                        yield return new WaitForSeconds(EStag);
                    }
                    p1 += 1;
                    Debug.Log(p1);

                    //Enemy 2 increases by2 each time
                    for (i = 0; i < p2; i++)
                    {
                        spawnEnemy(2);
                        yield return new WaitForSeconds(EStag);
                    }
                    p2 += 2;

                    if (WaveCounter >= 15)
                    {
                        for (i = 0; i < p3; i++)
                        {
                            spawnEnemy(1);
                            yield return new WaitForSeconds(EStag);
                        }
                        p3 += 3;
                    }
                }
            }
            else if (WaveCounter <= 20)
            {
                spawnEnemy(2);
                yield return new WaitForSeconds(EStag);
            }
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
            if (countdown <= 0f)
            {
                audioSource.Play();
                WaveCounter++;
                StartCoroutine(WaveSystem());
                countdown = timeBetweenWaves;
                if (WaveCounter == 12)
                {
                    p3 = 3;
                    p1 = 3;
                    p2 = 2;
                }
            }
            countdown -= Time.deltaTime;
        }
    }
}
