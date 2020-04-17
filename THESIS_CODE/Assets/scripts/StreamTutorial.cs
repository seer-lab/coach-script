using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip clip1;

    public void PlayTutorial()
    {
        StartCoroutine(Playtutorial());
    }

    IEnumerator Playtutorial()
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

    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }
}
