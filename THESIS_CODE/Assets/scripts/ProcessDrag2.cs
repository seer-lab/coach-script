using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class ProcessDrag2 : MonoBehaviour
{
    Transform[] blocks_t1;
    public GameObject Panel1;
    public GameObject Panel2;

    public Text changeText;


    public void Example2()
    {
        blocks_t1 = GetActionBlocks_MultiThreads("1");

        bool isCorrect = false;

        List<string> rightlist2 = new List<string>();
        rightlist2.Add("Catch();");
        rightlist2.Add("HasBall = true;");
        rightlist2.Add("Dribble();");
        rightlist2.Add("Pass();");
        rightlist2.Add("HasBall = false;");
        rightlist2.Add("Run();");
        rightlist2.Add("Catch();");
        rightlist2.Add("HasBall = true;");
        rightlist2.Add("Jump();");
        rightlist2.Add("Shoot();");



        List<string> blocks_names_t1 = new List<string>();

        string results = "";

        int i = 0;

        foreach (Transform child in blocks_t1)
        {
            if (i == 0)
            {
                isCorrect = true;
            }

            if (i >= rightlist2.Count)
            {
                Debug.Log("WRONG");
                results = results + "\n " + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " WRONG";
                isCorrect = false;
                break;
            }


            if (blocks_t1[i].transform.GetComponentInChildren<Text>().text == rightlist2[i])
            {
                Debug.Log(blocks_t1[i].transform.GetComponentInChildren<Text>().text + "CORRECT");
                results = results + "\n " + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " CORRECT";


            }
            else
            {
                Debug.Log(blocks_t1[i].transform.GetComponentInChildren<Text>().text + "WRONG");
                isCorrect = false;
                results = results + " \n" + blocks_t1[i].transform.GetComponentInChildren<Text>().text + " WRONG";
                break;

            }

            i++;
        }

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
