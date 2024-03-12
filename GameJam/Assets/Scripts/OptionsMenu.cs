using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDD;

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDD.value);
    }
}
