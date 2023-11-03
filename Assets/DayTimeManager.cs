using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    public GameObject dayTimeUI;
    public GameObject playerController;
    public GameObject barricadeManager;
    public GameObject enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNextNight()
    {
        dayTimeUI.SetActive(false);
        enemySpawner.SetActive(true);
        enemySpawner.GetComponent<EnemySpawner>().spawnCounter = 0;
        GetComponent<GameEventTracker>().isDay = false;
    }
}
