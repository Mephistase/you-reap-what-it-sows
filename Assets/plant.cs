using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{


    public float waterValue=100f;
    public float tooMuchWater=0f;
    public float dehydratationValue=1f;
    public bool pause=false;
    public PassingTime clock;
    
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_need;
    Color m_dead;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.white;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pause=clock.pause;
        if(pause==false){
            waterValue-=Time.deltaTime*dehydratationValue;
            aspectChange();
        }
    }

    public void water(){
        waterValue+=50f;
        if (waterValue>150f){
            waterValue=150f;
        }
    }
    private void overWater(){
        tooMuchWater+=Time.deltaTime*dehydratationValue/2f;
    }

    private void waterEnding(){
        //blah
    }

    private void dehydratationEnding(){
        //blah
    }

    private void aspectChange(){
        m_need = new Color(1f,1f,0.5f,1f);
        m_dead = new Color(1f,0.7f,0.5f,1f);
        if (waterValue>100f){
            overWater();
            GameObject.Find("/WATER").transform.GetChild(0).gameObject.SetActive(true);
            m_SpriteRenderer.color = Color.white;
        }
        else if(waterValue>50f){

            GameObject.Find("/WATER").transform.GetChild(0).gameObject.SetActive(false);
            m_SpriteRenderer.color = Color.white;
        }
        else if(waterValue>25f){
            m_SpriteRenderer.color = m_need;
        }
        else{
            m_SpriteRenderer.color = m_dead;
        }
    }


}
