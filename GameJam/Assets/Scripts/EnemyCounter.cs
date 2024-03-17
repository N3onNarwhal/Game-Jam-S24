using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public TextMeshProUGUI enemyCountText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = "Enemies : " + enemies.Length.ToString();

        if (enemies.Length == 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
