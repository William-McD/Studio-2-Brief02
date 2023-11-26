using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyNormal;
    public GameObject enemyQuick;
    public GameObject enemyTank;
    public float spawnRadius;


    [SerializeField] float countdownTimer;
    [SerializeField] float countdownTimerStart;

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

    void SpawnList01()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 10; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;

        }
        if (countdownCheck == 50f && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;

        }
        if (countdownCheck == 38 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);

            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 15 && spawnCounter == 8)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 10 && spawnCounter == 9)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
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
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 51 && spawnCounter == 1) 
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 10 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
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
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;

        }
    }
    void SpawnList04()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 8; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
    }
    void SpawnList05()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 10; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 
        if (countdownCheck == 55 && spawnCounter == 0)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            spawnCounter++;
        }
        if (countdownCheck == 50 && spawnCounter == 1)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 45 && spawnCounter == 2)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 40 && spawnCounter == 3)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 35 && spawnCounter == 4)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 30 && spawnCounter == 5)
        {
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyNormal);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            SpawnEnemyOnEdge(enemyQuick);
            spawnCounter++;
        }
        if (countdownCheck == 20 && spawnCounter == 6)
        {
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
        if (countdownCheck == 18 && spawnCounter == 7)
        {
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            SpawnEnemyOnEdge(enemyTank);
            spawnCounter++;
        }
    }
    void SpawnList06()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 10; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 

    }
    void SpawnList07()
    {
        SpawnTimer();
        int countdownCheck = (int)countdownTimer; //needs to convert timer float into an int to allow the programm a chance to read it
        spawnCounterLimit = 10; // spawn limit is 10 times for Day01
        //the reason why the if function needs the spawnCounter is to stop the spawning of enemies even if the countdownCheck remains accurate 

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
