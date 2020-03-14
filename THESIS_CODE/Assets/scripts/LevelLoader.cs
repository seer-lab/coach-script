using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject volumeOnIcon;
    public GameObject volumeOffIcon;

    // Use this for initialization
    void Start()
    {
        volumeOffIcon.SetActive(false);
    }

    public void playMusic()
    {
        volumeOnIcon.SetActive(false);
        volumeOffIcon.SetActive(true);
    }

    public void pauseMusic()
    {
        volumeOnIcon.SetActive(true);
        volumeOffIcon.SetActive(false);
    }


    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

       
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            //slider.value = progress;

            yield return null;
        }
    }
}
