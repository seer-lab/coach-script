using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.Video;

public class LevelThreeProcessM : MonoBehaviour
{
    string Path;
    string jsonString;

    Transform[] blocks_t1;
    public GameObject Panel1;
    public GameObject Panel2;

    public Text changeText;

    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip Mclipone;
    public VideoClip Mcliptwo;
    public VideoClip Mclipthree;
    public VideoClip Mclipfour;
    public VideoClip Mclipfive;
    public VideoClip Mclipsix;
    public VideoClip Mclipseven;
    public VideoClip Mclipeight;
    public VideoClip Mclipnine;
    public VideoClip Mclipten;



    public VideoClip Mmistake;

    List<string> codelist = new List<string>();


    // Start is called before the first frame update
    public void Playvideo(bool isCorrect)
    {
        StartCoroutine(PlayVideo(isCorrect));

    }


    IEnumerator PlayVideo(bool isCorrect)
    {

        foreach (string code in codelist)
        {
            if (code == "Pass();")
            {
                videoPlayer.clip = Mclipone;
            }
            if (code == "Run();")
            {
                videoPlayer.clip = Mcliptwo;
            }
            if (code == "Dribble();")
            {
                videoPlayer.clip = Mclipthree;
            }
            if (code == "Catch();")
            {
                videoPlayer.clip = Mclipfour;
            }
            if (code == "Catch();")
            {
                videoPlayer.clip = Mclipfive;
            }
            if (code == "Run();")
            {
                videoPlayer.clip = Mclipsix;
            }
            if (code == "Layup();")
            {
                videoPlayer.clip = Mclipseven;
            }
            if (code == "Jump();")
            {
                videoPlayer.clip = Mclipeight;
            }
            if (code == "Shoot();")
            {
                videoPlayer.clip = Mclipnine;
            }
            if (code == "Dunk();")
            {
                videoPlayer.clip = Mclipten;
            }




            if (code == "Wrong();")
            {
                videoPlayer.clip = Mmistake;
            }


            Debug.Log("code === " + code);

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
            WaitForSeconds waitForSeconds2 = new WaitForSeconds(2);
            while (videoPlayer.isPlaying)
            {
                yield return waitForSeconds2;
                break;
            }
            videoPlayer.Stop();
            audioSource.Stop();

        }

        if (isCorrect)
        {

            Debug.Log("Congrats");
            if (Panel1 != null)
            {
                Panel1.SetActive(true);

            }
        }
        else
        {
            Debug.Log("Incorrect try again");
            if (Panel2 != null)
            {
                Panel2.SetActive(true);
                codelist.Clear();
            }
        }
    }


    public void processlevel()
    {
        blocks_t1 = GetActionBlocks_MultiThreads("1");
        bool isCorrect = false;
        Path = Application.streamingAssetsPath + "/Level3.json";
        jsonString = File.ReadAllText(Path);
        Level3 Yumo = JsonUtility.FromJson<Level3>(jsonString);


        string[] rightlist = Yumo.CorrectOrder;
        List<string> blocks_names_t1 = new List<string>();
        string results = "";
        int i = 0;




        foreach (Transform child in blocks_t1)
        {
            if (i == 0)
            {
                isCorrect = true;
            }

            if (i >= rightlist.Length)
            {
                //Debug.Log("WRONG");
                //results = results + "\n " + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " WRONG";
                codelist.Add("Wrong();");
                isCorrect = false;
                break;
            }
            if (blocks_t1[i].transform.GetComponentInChildren<Text>().text == rightlist[i])
            {

                //Debug.Log(blocks_t1[i].transform.GetComponentInChildren<Text>().text + "CORRECT");
                //results = results + "\n " + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " CORRECT";
                codelist.Add(blocks_t1[i].transform.GetComponentInChildren<Text>().text);

            }
            else
            {

                //Debug.Log(blocks_t1[i].transform.GetComponentInChildren<Text>().text + "WRONG");
                //results = results + " \n" + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " WRONG";
                codelist.Add("Wrong();");
                isCorrect = false;
                break;
            }

            i++;
        }

        Playvideo(isCorrect);

        /*
        changeText.text = results;

        if (isCorrect)
        {

            Debug.Log("Congrats");
            if (Panel1 != null)
            {
                Panel1.SetActive(true);

            }
        }
        else
        {
            Debug.Log("Incorrect try again");
            if (Panel2 != null)
            {
                Panel2.SetActive(true);
            }
        }
        */
    }

    private Transform[] GetActionBlocks_MultiThreads(String tabNum)
    {

        //get children in drop area for thread

        string path = "";

        if (tabNum == "1")
            path = "DropZoneVertical";
        else
            path = "Tab2/ScrollRect/Holder/DropAreaThread2";

        Debug.Log("children: " + GameObject.Find(path).transform.childCount);
        int childCount = GameObject.Find(path).transform.childCount;

        Transform[] threadChildren = new Transform[childCount];


        for (int i = 0; i < childCount; i++)
        {

            threadChildren[i] = GameObject.Find(path).transform.GetChild(i);
        }

        return threadChildren;
    }
}
