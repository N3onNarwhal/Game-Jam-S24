using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour
{
    public RawImage ri;
    public VideoPlayer vidPlayer; 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        vidPlayer.Prepare();
        WaitForSeconds wfs = new WaitForSeconds(0);
        while (!vidPlayer.isPrepared)
        {
            yield return wfs;
            break;
        }
        ri.texture = vidPlayer.texture;
        vidPlayer.Play();
    }
}
