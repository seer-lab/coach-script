using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip clip1;
    public VideoClip clip2;




    // Start is called before the first frame update
    public void Playvideo()
    {
        StartCoroutine(PlayVideo());
    }

    public void Playvideo2()
    {
        StartCoroutine(PlayVideo2());
    }

   

    IEnumerator PlayVideo()
    {
        videoPlayer.clip = clip1;
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
    }

    IEnumerator PlayVideo2()
    {
        videoPlayer.clip = clip2;
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
    }





    // Update is called once per frame
    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }
}
