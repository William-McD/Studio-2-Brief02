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

    public TMP_Text whatDayText;

    int energyPoints;
    public TMP_Text energyPointText;

    public int startingBarricadeHealth;
    public TMP_Text barricadeRepairText;
    int dayBarricadeRepair;

    [SerializeField] int trueValue;

    float startingGunOverheatLimit;
    public TMP_Text overheatImprovementText;
    float dayGunOverheatImprovement;





    // Start is called before the first frame update
    public void SetUpDaytimeValues()
    {
        startingBarricadeHealth = barricadeManager.GetComponent<BarricadeManager>().barricadeHealth;
        dayBarricadeRepair = startingBarricadeHealth;

        startingGunOverheatLimit = playerController.GetComponent<PlayerController>().gunOverheatLimit;
        dayGunOverheatImprovement = startingGunOverheatLimit;
        energyPoints = 6;
    }

    // Update is called once per frame
    void Update()
    {
        int day = GetComponent<GameEventTracker>().nightCounter - 1;
        whatDayText.text = ("Day " + day);
        energyPointText.text = ("Energy Points: " + energyPoints);

        barricadeRepairText.text = (dayBarricadeRepair + "%");
        overheatImprovementText.text = (dayGunOverheatImprovement + "0%");

        
    }
    public void BarricadeRepairPlus()
    {
        if (dayBarricadeRepair < 96 && energyPoints > 0)
        {
            dayBarricadeRepair += 5;
            energyPoints--;
        }
        //Basically stops overspill of repair
        else if (dayBarricadeRepair > 95 && dayBarricadeRepair < 100 && energyPoints > 0 && trueValue == 0 )
        {
            trueValue = dayBarricadeRepair += 5;
            dayBarricadeRepair = 100;
            energyPoints--;
        }
    }
    public void BarricadeRepairMinus()
    {
        if (dayBarricadeRepair < 100 && dayBarricadeRepair > startingBarricadeHealth && energyPoints < 6)
        {
            dayBarricadeRepair -= 5;
            energyPoints++;

        }
        else if (dayBarricadeRepair == 100 && energyPoints < 6 && trueValue > 0)
        {
            dayBarricadeRepair = trueValue -= 5;
            trueValue -= trueValue;
            energyPoints++;

        }
    }

    public void GunImprovementPlus()
    {
        if (energyPoints > 0)
        {
            dayGunOverheatImprovement += 1;
            energyPoints--;

        }
    }

    public void GunImprovementMinus()
    {
        if (dayGunOverheatImprovement > startingGunOverheatLimit && energyPoints < 6)
        {
            dayGunOverheatImprovement -= 1;
            energyPoints++;

        }
    }


    public void StartNextNight()
    {
        dayTimeUI.SetActive(false);
        enemySpawner.SetActive(true);
        enemySpawner.GetComponent<EnemySpawner>().spawnCounter = 0;
        playerController.SetActive(true);
        playerController.GetComponent<PlayerController>().gunOverheatLimit = dayGunOverheatImprovement;
        playerController.GetComponent<PlayerController>().gunCooldown = 0f;
        GetComponent<GameEventTracker>().isDay = false;
    }
}
