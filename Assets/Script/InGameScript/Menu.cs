using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Text rest;
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
