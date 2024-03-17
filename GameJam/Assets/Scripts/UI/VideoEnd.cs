using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoEnd : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;
    float videoTime;
 
 
    //when video end, change scene
    void Start()
    {
        videoTime = (float)videoPlayer.length;
        Invoke("videoEnded", videoTime);
    }
 
 
 
    void videoEnded()
    {
        SceneManager.LoadScene("Level_1");
    }
}
