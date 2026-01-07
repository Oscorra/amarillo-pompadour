using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public string escenaSiguiente = "Nivel2";
    private VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();

        video.isLooping = false;
        video.skipOnDrop = true;
        video.sendFrameReadyEvents = true;

        Time.timeScale = 0;

        video.frameReady += CheckFinalFrame;

        video.Play();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            ReanudarYSalir();
        }
    }

    void CheckFinalFrame(VideoPlayer vp, long frame)
    {
        if (frame >= (long)vp.frameCount - 2)
        {
            ReanudarYSalir();
        }
    }

    void ReanudarYSalir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
