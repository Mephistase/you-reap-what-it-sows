using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingTime : MonoBehaviour
{
    public storyManager manager;
    Quaternion startRotation=new Quaternion(0f,0f,-45f,0f);

    public Vector3 spin=new Vector3(0f,0f,5f);
    public float realTime=120f;
    public float currentTime=0f;
    public bool dayFinished=false;
    public bool pause=true;

    void Start()
    {
        //transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTime<realTime && pause==false){
            currentTime+=Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(currentTime/realTime*360f-90f, Vector3.back);
        }
        else if(dayFinished==false && currentTime>=realTime){
            transform.rotation = Quaternion.AngleAxis(-90f, Vector3.back);
            dayFinished=true;
        }
    }

    public void pauseTime(){
        pause=true;
    }
    public void resumeTime(){
        pause=false;
    }
    public void newDay(){
        dayFinished=false;
        currentTime=0f;
    }
}
