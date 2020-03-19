﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelinfoW : MonoBehaviour
{
    string Path;
    string jsonString;

    public GameObject code;
    public GameObject drawerGO;

    public GameObject drop;

    public static LevelinfoW Instance { get; private set; }

    //public int Levelnumber = 1;


    public bool Character = false;
    string name1 = "Michael";
    string name2 = "Catherine";

    Text txt = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void selectcharacter()
    {
        Character = true;
        if (Character)
        {
            Debug.Log(name1);
        }
        else
        {
            Debug.Log(name2);
        }
    }

    public void emptyDropZone()
    {

        for (int i = 0; i < drop.transform.childCount; i++)
        {
            Destroy(drop.transform.GetChild(i).gameObject);
        }

    }

    public void getInfo1()
    {
        emptyDropZone();

        Path = Application.streamingAssetsPath + "/Level1.json";
        jsonString = File.ReadAllText(Path);
        Level1W Yumo = JsonUtility.FromJson<Level1W>(jsonString);
        Debug.Log(Yumo.Name);

        for (int i = 0; i < Yumo.ScreenOrder.Length; i++)
        {
            GameObject newInstance = (GameObject)Instantiate(code);
            newInstance.transform.SetParent(drawerGO.transform);

            newInstance.GetComponentInChildren<Text>().text = Yumo.ScreenOrder[i];
        }

    }

}

[System.Serializable]
public class Level1W
{
    public string Name;
    public int Level;
    public string[] CorrectOrder;
    public string[] ScreenOrder;
}
