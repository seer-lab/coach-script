using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessInput : MonoBehaviour
{
    public string funcone;
    public string functwo;
    public string functhree;

    public string congrats = "Congrats, Awesome Job!!!";
    public string wrong = "Incorrect order! remember to add semi-colon at the end";

    public GameObject inputField1;
    public GameObject inputField2;
    public GameObject inputField3;

    public GameObject textDisplay;

    public void Process()
    {
        funcone = inputField1.GetComponent<Text>().text;
        functwo = inputField2.GetComponent<Text>().text;
        functhree = inputField3.GetComponent<Text>().text;

        if (CheckAnswer(funcone, functwo, functhree))
        {
            textDisplay.GetComponent<Text>().text = congrats;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = wrong;
        }

    }

    public bool CheckAnswer(string one, string two, string three)
    {
        if(one == "HasBall = true;" && two == "Jump();" && three == "Shoot();")
        {
            return true;
        }
        else
        {
            return false;
        }
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
