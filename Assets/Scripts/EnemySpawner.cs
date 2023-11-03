using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRadius;


    [SerializeField] float countdownTimer;
    public float countdownTimerStart;

    public float countdownTimerDayOne;
    public float countdownTimerDayTwo;
    public float countdownTimerDayThree;
    public float countdownTimerDayFour;


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
            spawnCounterLimit = 10;
            SpawnTimer();
        }

        if (currentNight == 2 && isDay == false) // NIGHT TWO
        {
            spawnCounterLimit = 15;
            SpawnTimer();
        }

        if (currentNight == 3 && isDay == false) // NIGHT THREE
        {
            spawnCounterLimit = 15;
            SpawnTimer();
        }

        if (currentNight == 4 && isDay == false) // NIGHT FOUR
        {
            spawnCounterLimit = 20;
            SpawnTimer();
        }

    }

    public void CountdownSwitch() 
    {
        if (currentNight == 1) // NIGHT ONE
        {
            countdownTimerStart = countdownTimerDayOne; 
        }

        if (currentNight == 2) // NIGHT TWO
        {
            countdownTimerStart = countdownTimerDayTwo;
        }

        if (currentNight == 3) // NIGHT THREE
        {
            countdownTimerStart = countdownTimerDayThree;
        }

        if (currentNight == 4) // NIGHT FOUR
        {
            countdownTimerStart = countdownTimerDayFour;
        }
    }

    void SpawnTimer()
    {
        if (countdownTimer >= 0 && spawnCounter < spawnCounterLimit)
        {
            countdownTimer -= Time.deltaTime;
        }
        else if (spawnCounter < spawnCounterLimit)
        {
            SpawnEnemyOnEdge();
            countdownTimer = countdownTimerStart;
            spawnCounter += 1;
        }
    }


    private void SpawnEnemyOnEdge()
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
