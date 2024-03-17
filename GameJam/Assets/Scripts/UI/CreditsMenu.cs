using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject mainMenu;

    void Start()
    {
        creditsMenu.SetActive(false);
    }

    public void BackButton()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenCredits ()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
