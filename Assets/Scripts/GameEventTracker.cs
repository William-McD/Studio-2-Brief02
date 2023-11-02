using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTracker : MonoBehaviour
{
    public float barricadeHealth;
    public bool playerAlive;

    public GameObject gameOverUI;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerAlive = player.GetComponent<PlayerController>().alive;

        if (playerAlive == false)
        {
            gameOverUI.SetActive(true);
        }
    }
}
