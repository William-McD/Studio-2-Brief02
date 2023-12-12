using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.CodeAnalysis;
using System;

public class GameEventTracker : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject dayTimeUI;
    public GameObject player;
    public GameObject enemySpawner;

    public float barricadeHealth;
    public bool isDay;

    public bool playerAlive;
    public bool overheated;

    public int spawnCounter;
    public int spawnCounterLimit;
    public GameObject[] ingameEnemies;

    public TMP_Text overheatText;

    public int nightCounter;
    public int nightCounterStart;
    public TMP_Text nightCounterText;


    private void Awake()
    {
        nightCounter = nightCounterStart;
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
        CheckOnNightCounter();
        ActivateDayTimeScreen();
    }
    void CheckOnPlayer()
    {
        playerAlive = player.GetComponent<PlayerController>().alive;

        if (playerAlive == false)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void CheckOnOverheat()
    {
        overheated = player.GetComponent<PlayerController>().overheated;

        if (overheated == false)
        {
            overheatText.color = Color.blue;
            overheatText.text = ("Ready to Fire!");
        }
        else
        {
            overheatText.color = Color.red;
            overheatText.text = ("Overheated!");
        }

    }

    void CheckOnEnemySpawner()
    {
        spawnCounter = enemySpawner.GetComponent<EnemySpawner>().spawnCounter;
        spawnCounterLimit = enemySpawner.GetComponent<EnemySpawner>().spawnCounterLimit;

        if (spawnCounter == spawnCounterLimit)
        {
            ingameEnemies = (GameObject.FindGameObjectsWithTag("Enemy"));
            if (ingameEnemies.Length == 0 && isDay == false) 
            {
                Debug.Log("YOU WIN (GAME TRANSITION HERE)");
                nightCounter += 1;
                enemySpawner.SetActive(false);
                player.SetActive(false);
                //spawnCounter = enemySpawner.GetComponent<EnemySpawner>().spawnCounter;

                GetComponent<DayTimeManager>().SetUpDaytimeValues();

                isDay = true;
            }
        }

    }

    void CheckOnNightCounter()
    {
        nightCounterText.text = ("Night: " + nightCounter);


    }

    void ActivateDayTimeScreen()
    {
        if (isDay == false)
        {
            dayTimeUI.SetActive(false);
        }
        else if(isDay == true) 
        {
            dayTimeUI.SetActive(true);
        }

    }
}
