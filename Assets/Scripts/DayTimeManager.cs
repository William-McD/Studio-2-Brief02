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

    public TMP_Text energyPointText;
    int energyPoints;

    public TMP_Text barricadeRepairText;
    public TMP_Text repairValueText;
    public int startingBarricadeHealth;
    int dayBarricadeRepair;
    int repairAmount;

    public TMP_Text droneAmountText;
    public int startingDroneAmount;
    int dayDroneAmount;


    [SerializeField] int trueValue;

    float startingGunOverheatLimit;
    public TMP_Text overheatImprovementText;
    float dayGunOverheatImprovement;

    // FIRST PLAYABLE ONLY----------------
    public GameObject nextDayButton;
    //------------------------------------


    // Start is called before the first frame update
    public void SetUpDaytimeValues()
    {
        if (barricadeManager.GetComponent<BarricadeManager>().barricadeHealth < 0)
        {
            startingBarricadeHealth = 0;
        }
        else
        {
            startingBarricadeHealth = barricadeManager.GetComponent<BarricadeManager>().barricadeHealth;
        }
        dayBarricadeRepair = startingBarricadeHealth;

        startingGunOverheatLimit = playerController.GetComponent<PlayerController>().gunOverheatLimit;
        dayGunOverheatImprovement = startingGunOverheatLimit;

        if (barricadeManager.GetComponent<BarricadeManager>().droneCount < 0)
        {
            startingDroneAmount = 0;
        }
        else
        {
            startingDroneAmount = barricadeManager.GetComponent<BarricadeManager>().droneCount;
        }
        dayDroneAmount = startingDroneAmount;


        energyPoints = 9;

    }

    // Update is called once per frame
    void Update()
    {
        int day = GetComponent<GameEventTracker>().nightCounter - 1;
        whatDayText.text = ("Day " + day);
        energyPointText.text = ("Energy Points: " + energyPoints);

        repairAmount = 5 + (5 * startingDroneAmount);

        barricadeRepairText.text = (dayBarricadeRepair + "%");
        repairValueText.text = ("Repair = " + repairAmount + "%");

        overheatImprovementText.text = (dayGunOverheatImprovement + "0%");
        droneAmountText.text = (dayDroneAmount + "/3");


        // FIRST PLAYABLE ONLY---------------- //Chris
        if (day == 7)
        {
            nextDayButton.SetActive(false);
        }
        //------------------------------------
    }
    public void BarricadeRepairPlus()
    {
        if (dayBarricadeRepair < (100 - (repairAmount + 1)) && energyPoints > 0)
        {
            dayBarricadeRepair += repairAmount;
            energyPoints--;
        }
        //Basically stops overspill of repair
        else if (dayBarricadeRepair >= (100 - (repairAmount+1)) && dayBarricadeRepair < 100 && energyPoints > 0 && trueValue == 0 )
        {
            trueValue = dayBarricadeRepair += repairAmount;
            dayBarricadeRepair = 100;
            energyPoints--;
        }
    }
    public void BarricadeRepairMinus()
    {
        if (dayBarricadeRepair < 100 && dayBarricadeRepair > startingBarricadeHealth && energyPoints < 9)
        {
            dayBarricadeRepair -= repairAmount;
            energyPoints++;
        }
        else if (dayBarricadeRepair == 100 && energyPoints < 8 && trueValue > 0)
        {
            dayBarricadeRepair = trueValue -= repairAmount;
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
        if (dayGunOverheatImprovement > startingGunOverheatLimit && energyPoints < 9)
        {
            dayGunOverheatImprovement -= 1;
            energyPoints++;
        }
    }

    public void DronePlus()
    {
        if (energyPoints >= 6 && dayDroneAmount < 3)
        {
            dayDroneAmount += 1;
            energyPoints -= 6;
        }
    }
    public void DroneMinus()
    {
        if (energyPoints <9 && dayDroneAmount > startingDroneAmount) 
        {
            dayDroneAmount -= 1;
            energyPoints += 6;
        }
    }



    public void StartNextNight()
    {
        dayTimeUI.SetActive(false);

        barricadeManager.GetComponent<BarricadeManager>().barricadeHealth = dayBarricadeRepair;
        barricadeManager.GetComponent<BarricadeManager>().droneCount = dayDroneAmount;
        barricadeManager.GetComponent<BarricadeManager>().DroneManager();

        enemySpawner.SetActive(true);
        enemySpawner.GetComponent<EnemySpawner>().spawnCounter = 0;
        enemySpawner.GetComponent<EnemySpawner>().countdownTimer = enemySpawner.GetComponent<EnemySpawner>().countdownTimerStart;
        enemySpawner.GetComponent<EnemySpawner>().currentNight++;

        playerController.SetActive(true);
        playerController.GetComponent<PlayerController>().gunOverheatLimit = dayGunOverheatImprovement;
        playerController.GetComponent<PlayerController>().gunCooldown = 0f;
        playerController.GetComponent<PlayerController>().ResetPosition();




        GetComponent<GameEventTracker>().isDay = false;
    }
}
