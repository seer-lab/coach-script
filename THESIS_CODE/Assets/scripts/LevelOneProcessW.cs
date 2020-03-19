﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.Video;

public class LevelOneProcessW : MonoBehaviour
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

    public VideoClip Wclipone;
    public VideoClip Wcliptwo;
    public VideoClip Wmistake;

    List<string> codelist = new List<string>();


    // Start is called before the first frame update
    public void Playvideo()
    {
        StartCoroutine(PlayVideo());

    }


    IEnumerator PlayVideo()
    {

        foreach (string code in codelist)
        {
   
                if (code == "Jump();")
                {
                    videoPlayer.clip = Wclipone;
                }
                if (code == "Shoot();")
                {
                    videoPlayer.clip = Wcliptwo;
                }
                if (code == "Wrong();")
                {
                    videoPlayer.clip = Wmistake;
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
            WaitForSeconds waitForSeconds2 = new WaitForSeconds(3);
            while (videoPlayer.isPlaying)
            {
                yield return waitForSeconds2;
                break;
            }
            videoPlayer.Stop();
            audioSource.Stop();

        }
    }


    public void processlevel()
    {
        blocks_t1 = GetActionBlocks_MultiThreads("1");
        bool isCorrect = false;
        Path = Application.streamingAssetsPath + "/Level1.json";
        jsonString = File.ReadAllText(Path);
        Level1 Yumo = JsonUtility.FromJson<Level1>(jsonString);


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

        Playvideo();

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
