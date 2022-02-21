using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlOption : MonoBehaviour
{
    private GameObject Player;
    private DriftButton DriftButton;
    private DriftSlider DriftSlider;
    public GameObject UiHandBrake;
    public GameObject UiHandBrakeLow;
    public GameObject UiSlider;



    private void Awake()
    {
        Player = GameObject.Find("RTI_Midnight");
        DriftButton=Player.GetComponent<DriftButton>();
        DriftSlider = Player.GetComponent<DriftSlider>();
      
    }
  

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void ChoiceButtonControl()
    {
        DriftButton.enabled = true;
        DriftSlider.enabled = false;
        UiHandBrake.SetActive(!UiHandBrake.activeSelf);
        UiHandBrakeLow .SetActive(!UiHandBrakeLow.activeSelf);
    }
    public void ChoiceSliderControl()
    {
        DriftButton.enabled = false;
        DriftSlider.enabled = true;
        UiSlider.SetActive(!UiSlider.activeSelf);
    }
}

