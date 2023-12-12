using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] normalEnemies;
    public GameObject[] quickEnemies;
    public GameObject[] tankEnemies;

    public float spawnRadius;


    public float countdownTimer;
    public float countdownTimerStart;

    public int spawnCounter;
    public int spawnCounterLimit;

    GameObject manager;
    public int currentNight;
    bool isDay;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        currentNight = manager.GetComponent<GameEventTracker>().nightCounter;
        isDay = manager.GetComponent<GameEventTracker>().isDay;
        countdownTimerStart = 60f;
        countdownTimer = countdownTimerStart;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentNight == 1 && isDay == false) // NIGHT ONE
        {
            SpawnList01();
        }
        if (currentNight == 2 && isDay == false) // NIGHT TWO
        {
            SpawnList02();
        }
        if (currentNight == 3 && isDay == false) // NIGHT Three
        {
            SpawnList03();
        }
        if (currentNight == 4 && isDay == false) // NIGHT FOUR
        {
            SpawnList04();
        }
        if (currentNight == 5 && isDay == false) // NIGHT FIVE
        {
            SpawnList05();
        }
        if (currentNight == 6 && isDay == false) // NIGHT SIX
        {
            SpawnList06();
        }
        if (currentNight == 7 && isDay == false) // NIGHT SEVEN
        {
            SpawnList07();
        }

    }

    void SpawnTimer()
    {
        if (countdownTimer >= 0)
        {
            countdownTimer -= Time.deltaTime;
        }
        else if (countdownTimer <= 0)
        {
            countdownTimer = countdownTimerStart;
        }
    }
    //--------------------------------------------------------------
    //Created array to spown enemy prefab types
    // 0 = Ordinary Enemy art | 1 = Gross/Green Enemy art
    //--------------------------------------------------------------
    void SpawnList01()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 10; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;

        }
        if (countdownCheck == 50f && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;

        }
        if (countdownCheck == 38 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);

            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 15 && spawnCounter == 8)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 10 && spawnCounter == 9)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
    }
    void SpawnList02()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 6; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 

        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 51 && spawnCounter == 1) 
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 10 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
    }
    void SpawnList03()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;

        }
    }
    void SpawnList04() // Chris
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
    }
    void SpawnList05() //Chris
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            spawnCounter++;
        }
    }
    void SpawnList06() //Nathan
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
                                //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[0]);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[2]);
            SpawnEnemyOnEdge(quickEnemies[2]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[0]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[0]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[0]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            spawnCounter++;
        }
    }
    void SpawnList07() //Nathan
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
                               //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 

        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(quickEnemies[1]);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(quickEnemies[1]);
            SpawnEnemyOnEdge(normalEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            SpawnEnemyOnEdge(tankEnemies[1]);
            spawnCounter++;
        }
    }
    private void SpawnEnemyOnEdge(GameObject enemy)
    {
        float radius = spawnRadius;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = transform.position.z;

        GameObject go = Instantiate(enemy, randomPos, Quaternion.identity);
        go.transform.position = randomPos;
    }

}
