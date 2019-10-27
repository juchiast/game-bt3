using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        vid = GetComponent<VideoPlayer>();
        vid.loopPointReached += NextScenePlease;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextScenePlease(VideoPlayer vp) {
        Application.LoadLevel("MainMenu");
    }
}
