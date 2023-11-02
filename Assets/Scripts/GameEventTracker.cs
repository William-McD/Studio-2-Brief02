using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTracker : MonoBehaviour
{
    public GameObject gameOverUI;

    public float barricadeHealth;
    public bool playerAlive;
    public bool isDay;


    public int spawnCounter;
    public int spawnCounterLimit;
    public GameObject[] ingameEnemies;



    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnPlayer();
       CheckOnEnemySpawner();
    }
    void CheckOnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerAlive = player.GetComponent<PlayerController>().alive;

        if (playerAlive == false)
        {
            gameOverUI.SetActive(true);
        }
    }

    void CheckOnEnemySpawner()
    {
        GameObject enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        spawnCounter = enemySpawner.GetComponent<EnemySpawner>().spawnCounter;
        spawnCounterLimit = enemySpawner.GetComponent<EnemySpawner>().spawnCounterLimit;

        if (spawnCounter == spawnCounterLimit)
        {
            ingameEnemies = (GameObject.FindGameObjectsWithTag("Enemy"));
            if (ingameEnemies.Length == 0) 
            {
                Debug.Log("YOU WIN (GAME TRANSITION HERE)");
                isDay = true;
            }
        }

    }
}
