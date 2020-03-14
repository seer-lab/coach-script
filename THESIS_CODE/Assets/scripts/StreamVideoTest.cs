using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideoTest : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip clipone;
    public VideoClip cliptwo;
    public VideoClip mistake;

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



        videoPlayer.clip = clipone;
        videoPlayer.Prepare();
        WaitForSeconds waitForS = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForS;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        WaitForSeconds waitForSeconds3 = new WaitForSeconds(1);
        while (videoPlayer.isPlaying)
        {
            yield return waitForSeconds3;
            break;
        }
        videoPlayer.Stop();
        audioSource.Stop();




        videoPlayer.clip = cliptwo;
        videoPlayer.Prepare();
        WaitForSeconds waitForS1 = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForS1;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();


    }

    // Update is called once per frame
    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }
}
