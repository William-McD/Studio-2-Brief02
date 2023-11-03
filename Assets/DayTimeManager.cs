using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayTimeManager : MonoBehaviour
{
    public GameObject dayTimeUI;
    public GameObject playerController;
    public GameObject barricadeManager;
    public GameObject enemySpawner;


    public int startingBarricadeHealth;
    float startingGunOverheatLimit;

    public int dayBarricadeRepair;
    float dayGunOverheatImprovement;

    public TMP_Text barricadeRepairText;
    public TMP_Text overheatImprovementText;

    // Start is called before the first frame update
    private void Awake()
    {
        startingBarricadeHealth = barricadeManager.GetComponent<BarricadeManager>().barricadeHealth;
        dayBarricadeRepair = startingBarricadeHealth;

        startingGunOverheatLimit = playerController.GetComponent<PlayerController>().gunOverheatLimit;
        dayGunOverheatImprovement = startingGunOverheatLimit;
    }

    // Update is called once per frame
    void Update()
    {
        barricadeRepairText.text = (dayBarricadeRepair + "%");
        overheatImprovementText.text = (dayGunOverheatImprovement + "0%");
    }
    public void BarricadeRepairPlus()
    {
        dayBarricadeRepair += 5;
    }
    public void BarricadeRepairMinus()
    {
        if (dayBarricadeRepair > (startingBarricadeHealth + 5))
        {
            dayBarricadeRepair -= 5;
        }
    }

    public void GunImprovementPlus()
    {
        dayGunOverheatImprovement += 1;
    }

    public void GunImprovementMinus()
    {
        if (dayGunOverheatImprovement > startingGunOverheatLimit)
        {
            dayGunOverheatImprovement -= 1;
        }
    }


    public void StartNextNight()
    {
        dayTimeUI.SetActive(false);
        enemySpawner.SetActive(true);
        enemySpawner.GetComponent<EnemySpawner>().spawnCounter = 0;
        playerController.SetActive(true);
        playerController.GetComponent<PlayerController>().gunOverheatLimit = dayGunOverheatImprovement;

        GetComponent<GameEventTracker>().isDay = false;
    }
}
