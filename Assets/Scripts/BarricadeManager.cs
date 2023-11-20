using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BarricadeManager : MonoBehaviour
{
    public int barricadeHealth;
    public TMP_Text barricadeText;
    GameObject[] barricades;

    //Nathan
    public GameObject ShieldedBarricadePrefab;
    public GameObject SlightlyDamagedBarricadePrefab;
    public GameObject HalfDamagedBarricadePrefab;
    public GameObject MostlyDamagedPrefab;
    public GameObject DestroyedBarricadePrefab;
    public bool ShieldedBarricade;
    public bool SlightlyDamaged;
    public bool HalfDamaged;
    public bool MostlyDamaged;
    public bool BarricadeDestroyed;
    public int barricadeHP;
    //Nathan

    public GameObject drone01;
    public GameObject drone02;
    public GameObject drone03;
    //public List <GameObject> droneList = new List <GameObject>();
    public int droneCount;

    private void Awake()
    {
        barricades = GameObject.FindGameObjectsWithTag("Barricade");
        drone01.SetActive(false);
        drone02.SetActive(false);
        drone03.SetActive(false);
    }

    //Nathan
    // Start is called before the first frame update
    void Start()
    {
        GameObject clone = Instantiate(ShieldedBarricadePrefab, transform.position, transform.rotation);
        clone.GetComponent<Barricade>().script = this;
        barricadeHP = 1;
    }
    //Nathan

    // Update is called once per frame
    void Update()
        {
            barricadeText.text = (barricadeHealth + "%");
            if (barricadeHealth <= 0)
            {
                DestroyBarricade();
            }
            else
            {
                foreach (GameObject b in barricades)
                {
                    b.SetActive(true);
                }
                //Nathan
                if ((SlightlyDamaged == false) && (barricadeHP == 2))
                {
                    GameObject clone = Instantiate(SlightlyDamagedBarricadePrefab, transform.position, transform.rotation);
                    clone.GetComponent<Barricade>().script = this;
                    SlightlyDamaged = true;
                }
                if ((HalfDamaged == false) && (barricadeHP == 3))
                {
                    GameObject clone = Instantiate(HalfDamagedBarricadePrefab, transform.position, transform.rotation);
                    clone.GetComponent<Barricade>().script = this;
                    HalfDamaged = true;
                }
                if ((MostlyDamaged == false) && (barricadeHP == 4))
                {
                    GameObject clone = Instantiate(MostlyDamagedPrefab, transform.position, transform.rotation);
                    clone.GetComponent<Barricade>().script = this;
                    MostlyDamaged = true;
                }
                if ((BarricadeDestroyed == false) && (barricadeHP == 5))
                {
                    GameObject clone = Instantiate(DestroyedBarricadePrefab, transform.position, transform.rotation);
                    clone.GetComponent<Barricade>().script = this;
                    BarricadeDestroyed = true;
                }
                //nathan
            }
        }
        void DestroyBarricade()
        {
            foreach (GameObject b in barricades)
            {
                b.SetActive(false);
            }
        }

        public void DroneManager()
        {
            if (droneCount == 1 && (drone01.activeInHierarchy || drone02.activeInHierarchy || drone03.activeInHierarchy))
            {
                return;
            }
            else if (droneCount == 1)
            {
                drone01.SetActive(true);
            }
            if (droneCount == 2 && (drone01.activeInHierarchy && drone03.activeInHierarchy))
            {
                return;
            }
            else if (droneCount == 2)
            {
                drone02.SetActive(true);
            }
            if (droneCount == 3)
            {
                drone01.SetActive(true);
                drone02.SetActive(true);
                drone03.SetActive(true);
            }

        }

    }
