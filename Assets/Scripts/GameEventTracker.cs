using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEventTracker : MonoBehaviour
{
    public GameObject gameOverUI;

    public float barricadeHealth;
    public bool isDay;

    public bool playerAlive;
    public bool overheated;

    public int spawnCounter;
    public int spawnCounterLimit;
    public GameObject[] ingameEnemies;

    public TMP_Text overheatText;


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
       CheckOnOverheat();
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

    void CheckOnOverheat()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        overheated = player.GetComponent<PlayerController>().overheated;

        if (overheated == false)
        {
            overheatText.color = Color.green;
            overheatText.text = ("Ready!");
        }
        else
        {
            overheatText.color = Color.red;
            overheatText.text = ("Overheated!");
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
