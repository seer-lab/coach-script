using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideoss : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;



    public VideoPlayer videoPlayer1;
    public AudioSource audioSource1;

    // Start is called before the first frame update
    public void Playvideo()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();

        WaitForSeconds waitForSeconds2 = new WaitForSeconds(1);
        while (videoPlayer.isPlaying)
        {
            yield return waitForSeconds2;
            break;
        }

        videoPlayer.Stop();
        audioSource.Stop();




        videoPlayer1.Prepare();
        WaitForSeconds waitForS = new WaitForSeconds(1);
        while (!videoPlayer1.isPrepared)
        {
            yield return waitForS;
            break;
        }

        rawImage.texture = videoPlayer1.texture;
        videoPlayer1.Play();
        audioSource1.Play();


    }

    // Update is called once per frame
    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }
}
