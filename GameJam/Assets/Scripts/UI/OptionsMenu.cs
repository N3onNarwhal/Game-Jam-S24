using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDD;
    [SerializeField] GameObject pauseMenu;

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDD.value);
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     pauseMenu.SetActive(true);
        // }
    }
}
