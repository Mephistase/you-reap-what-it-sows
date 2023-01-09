using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class choiceButtons : MonoBehaviour
{

    public TMP_Text questionTMP;
    public TMP_Text A1TMP;
    public TMP_Text A2TMP;

    public string questionText;
    public string A1Text;
    public string A2Text;

    public bool chosenA1=false;
    public bool chosenA2=false;

    // Update is called once per frame
    void Update()
    {
        questionTMP.text=questionText;
        A1TMP.text=A1Text;
        A2TMP.text=A2Text;
    }
    public void chooseA1(){
        chosenA1=true;
        chosenA2=false;
    }

    public void chooseA2(){
        chosenA1=false;
        chosenA2=true;
    }
}
