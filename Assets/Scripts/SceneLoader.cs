using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject tutScreen;
    [SerializeField] private GameObject buttons;
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void openScreen()
    {
        tutScreen.SetActive(true);
       // buttons.SetActive(false);
    }

    public void closeScreen()
    {
        tutScreen.SetActive(false);
     //   buttons.SetActive(true);
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
