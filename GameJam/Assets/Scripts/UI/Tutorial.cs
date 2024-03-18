using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen;
    
    void Start()
    {
        tutorialScreen.SetActive(true);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(20);
        tutorialScreen.SetActive(false);
    }
}
