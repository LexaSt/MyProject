using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //private Text rest;
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void ReloadLevelOption()
    {
        SceneManager.LoadScene(2);

    }
    public void ReloadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadTraining()
    {
        SceneManager.LoadScene(3);
    }
}

