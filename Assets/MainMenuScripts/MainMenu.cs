using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // SceneManager.LoadScene("GameScene"); Scene To load will change depending on the name of the Game Scene
        Debug.Log("Starting Game");
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }
}
