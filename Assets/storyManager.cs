using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class storyManager : MonoBehaviour
{
    public plant plant;
    public GameObject branch;
    public GameObject EndBlock;
    public GameObject fruit;
    public GameObject rainbow;
    public choiceButtons choices;
    public GameObject choiceBlock;
    public GameObject computer;
    public GameObject computerBlock;
    public GameObject soundBlock;
    public AudioSource Door;
    public AudioSource mainTheme;
    public AudioSource sleepingNoise;
    public AudioSource felicity;
    public AudioSource felicityTwisted;
    public GameObject workButton;
    public GameObject waterButton;
    public PassingTime clock;
    public TMP_Text moneyText;
    public GameObject playerCanvas;
    public TMP_Text playerText;
    public GameObject plantCanvas;
    public TMP_Text plantText;
    public GameObject otherCanvas;
    public TMP_Text otherText;


    public messages[] allMessages;
    public messages error;


    public int currentDay=1;
    public int money=100;
    private float currentTime=0f;
    public int workedDay=0;
    public int giftToPlant=0;

    public bool reading=false;
    public bool waterWarning=false;
    public string currentMessage="A1";

    void Awake()
    {
        clock.pauseTime();
        StartCoroutine(firstDay());
        clock.currentTime=0f;
    }

    void Update()
    {
        if(currentDay>=2){
            waterButton.SetActive(false);
        }
        if (plant.tooMuchWater>=60f){
            currentMessage="EndTMW";
            OpenMessage(findMessageId(currentMessage));
            plant.tooMuchWater=0f;
        }
        if(plant.waterValue<=0f){
            currentMessage="EndNW";
            OpenMessage(findMessageId(currentMessage));
            plant.waterValue=100f;
        }
        if(currentMessage=="Died"){
            EndBlock.SetActive(true);
            clock.pauseTime();
        }
        if(currentMessage=="EndGR"){
            OpenMessage(findMessageId(currentMessage));
        }

        currentTime=clock.currentTime/clock.realTime;
        moneyText.text=money.ToString();


        if(currentTime>=0.15f && currentTime<0.16f){
           waterButton.SetActive(true);
        }
        if(currentTime>=0.4f && currentTime<0.41f){
            workButton.SetActive(true);
        }
        if(currentDay==2 && currentTime>=0.1f){
            waterButton.SetActive(true);
        }



        if(choices.chosenA1 && currentMessage=="AnsQ1"){
            money-=50;
            choices.chosenA1=false;
            giftToPlant++;
            resumeTime();
        }
        else if(choices.chosenA2 && currentMessage=="AnsQ1"){
            choices.chosenA2=false;
            resumeTime();
        }



        if(reading==false && currentMessage!="none" && currentMessage!="AnsQ1"){
            if (currentDay==1){
                if(currentMessage[0]=='A'){
                    OpenMessage(findMessageId(currentMessage));
                }
                else if (currentTime>0.149f && currentMessage=="Z1") {
                    OpenMessage(findMessageId(currentMessage));
                }
                else if (currentTime>0.399f && currentMessage=="Z2") {
                    OpenMessage(findMessageId(currentMessage));
                }
                else if (currentTime>0.7f && currentMessage=="Z3" && workedDay==0) {
                    OpenMessage(findMessageId(currentMessage));
                    }
                else if (currentMessage=="Q1" && workedDay==0) {
                    AskQuestion("Buy fertilizer for 50$?","Yes","No");
                }
                else if(plant.tooMuchWater>0f && waterWarning==false){
                    currentMessage="W1";
                    OpenMessage(findMessageId(currentMessage));
                    waterWarning=true;
                }
            }
        }
        if(clock.dayFinished && currentDay==1 && currentMessage!="endD1"){
            workButton.SetActive(false);
            waterButton.SetActive(false);
            if(currentMessage[0]!='B'){
                currentMessage="B1";
            }
            if(currentMessage[0]=='B'){
                OpenMessage(findMessageId(currentMessage));
            }
        }
            
        

        if(currentMessage=="endD1"){
            newDay();
            currentMessage="C1";
            branch.SetActive(true);
            fruit.SetActive(true);
        }

        if(reading==false && currentMessage!="none"){
            if(currentDay==2){
                if(currentMessage[0]=='C'){
                    OpenMessage(findMessageId(currentMessage));
                }
                if(currentMessage=="C3"){
                    mainTheme.Stop();
                    felicity.Play();
                    rainbow.SetActive(true);
                    fruit.SetActive(false);
                }
                if(currentMessage=="C6"){
                    felicity.Stop();
                    felicityTwisted.Play();
                }
                if(currentMessage=="C7"){
                    felicityTwisted.Stop();
                    mainTheme.Play();
                    rainbow.SetActive(false);
                }
                if(currentMessage=="Q2"){
                    AskQuestion("Get rid of your dear buddy?","How could i?","Yes");
                }
            }
        }
        if(currentMessage=="D1"){
            OpenMessage(findMessageId(currentMessage));
        }
        if(currentMessage=="D2"){
            newDay();
            currentMessage="E1";
        }

        if(reading==false && currentMessage!="none"){
            if(currentDay==3){
                if(currentMessage[0]=='E'){
                    OpenMessage(findMessageId(currentMessage));
                }
                if(currentMessage=="E2"){
                    rainbow.SetActive(true);
                    mainTheme.Stop();
                    felicity.Play();
                }
                if(currentMessage=="E3"){
                    felicity.Stop();
                    felicityTwisted.Play();
                }
            }
        }
    }

    void AskQuestion(string questionText,string A1text,string A2text){
        reading=true;
        clock.pauseTime();
        choiceBlock.SetActive(true);
        choices.A1Text=A1text;
        choices.A2Text=A2text;
        choices.questionText=questionText;
    }

    void OpenMessage(messages message){
        reading=true;
        clock.pauseTime();
        if(message.actor=="player"){
            playerCanvas.SetActive(true);
            playerText.text=message.message;
        }
        else if(message.actor=="plant"){
            plantCanvas.SetActive(true);
            plantText.text=message.message;
        }
        else if(message.actor=="other"){
            otherCanvas.SetActive(true);
            otherText.text=message.message;
        }        
    }

    public void newDay(){
        currentDay+=1;
        clock.pauseTime();
        StartCoroutine(sleepAnimation());
        workButton.SetActive(false);
        waterButton.SetActive(false);
        plant.waterValue=50f;

    }

    private messages findMessageId(string targetId){
        foreach(messages whoIsIt in allMessages){
            if(whoIsIt.Id==targetId){
                return whoIsIt;
            }
        }
        return error;
    }

    public void resumeTime(){
        clock.resumeTime();
    }

    public void goToWork(){
        clock.pauseTime();
        workedDay++;
        money+=50;
        StartCoroutine(workAnimation());
        
        
    }



    IEnumerator workAnimation()
    {
        mainTheme.Stop();
        Door.Play();
        computerBlock.SetActive(true);
        workButton.SetActive(false);
        waterButton.SetActive(false);
        yield return new WaitForSeconds(6);
        computer.SetActive(true);
        yield return new WaitForSeconds(3);
        computer.SetActive(false);
        Door.Play();
        yield return new WaitForSeconds(6);
        computerBlock.SetActive(false);
        mainTheme.Play();
        clock.resumeTime();
        clock.currentTime=clock.realTime*0.8f;
        waterButton.SetActive(true);
        plant.waterValue-=50f;
    }

    IEnumerator sleepAnimation()
    {
        waterButton.SetActive(false);
        mainTheme.Stop();
        computerBlock.SetActive(true);
        sleepingNoise.Play();
        yield return new WaitForSeconds(8);
        computerBlock.SetActive(false);
        clock.newDay();
        mainTheme.Play();
        waterButton.SetActive(true);
    }

    IEnumerator firstDay()
    {
        computerBlock.SetActive(true);
        soundBlock.SetActive(true);
        yield return new WaitForSeconds(5);
        soundBlock.SetActive(false);
        Door.Play();
        yield return new WaitForSeconds(5);
        computerBlock.SetActive(false);
        mainTheme.Play();
    }


}
