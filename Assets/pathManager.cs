using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour
{
    public storyManager manager;
    public choiceButtons choices;
    public void nextMessage(){
        manager.reading=false;
        
        if(manager.currentMessage=="A1"){
            manager.currentMessage="A2";
        }
        else if(manager.currentMessage=="A2"){
            manager.currentMessage="A3";
        }
        else if(manager.currentMessage=="A3"){
            manager.currentMessage="A4";
        }
        else if(manager.currentMessage=="A4"){
            manager.currentMessage="A5";
        }
        else if(manager.currentMessage=="A5"){
            manager.currentMessage="A6";
        }
        else if(manager.currentMessage=="A6"){
            manager.currentMessage="Z1";
        }
        else if(manager.currentMessage=="Z1"){
            manager.currentMessage="Z2";
        }
        else if(manager.currentMessage=="W1"){
            manager.currentMessage="Z2";
        }
        else if(manager.currentMessage=="Z2"){
            manager.currentMessage="Z3";
        }
        else if(manager.currentMessage=="Z3"){
            manager.currentMessage="Q1";
        }
        else if(manager.currentMessage=="Q1"){
            manager.currentMessage="AnsQ1";
        }
        else if(manager.currentMessage=="AnsQ1"){
            manager.currentMessage="none";
        }
        else if(manager.currentMessage=="B1"){
            manager.currentMessage="B2";
        }
        else if(manager.currentMessage=="B2"){
            manager.currentMessage="B3";
        }
        else if(manager.currentMessage=="B3"){
            manager.currentMessage="B4";
        }
        else if(manager.currentMessage=="B4"){
            manager.currentMessage="B5";
        }
        else if(manager.currentMessage=="B5"){
            manager.currentMessage="endD1";
        }
        else if(manager.currentMessage=="C1"){
            manager.currentMessage="C2";
        }
        else if(manager.currentMessage=="C2"){
            manager.currentMessage="C3";
        }
        else if(manager.currentMessage=="C3"){
            manager.currentMessage="C4";
        }
        else if(manager.currentMessage=="C4"){
            manager.currentMessage="C5";
        } 
        else if(manager.currentMessage=="C5"){
            manager.currentMessage="C6";
        } 
        else if(manager.currentMessage=="C6"){
            manager.currentMessage="C7";
        } 
        else if(manager.currentMessage=="C7"){
            manager.currentMessage="Q2";
        } 
        else if(manager.currentMessage=="EndTMW"){
            manager.currentMessage="Died";
        }    
        else if(manager.currentMessage=="EndNW"){
            manager.currentMessage="Died";
        }    
        else if(manager.currentMessage=="EndGR"){
            manager.currentMessage="Died";
        } 
        else if(manager.currentMessage=="Q2"){
            if(choices.chosenA1){
                manager.currentMessage="D1";
            }
            if(choices.chosenA2){
                manager.currentMessage="EndGR";
            }
        } 
        else if(manager.currentMessage=="D1"){
            manager.currentMessage="D2";
        }  
        else if(manager.currentMessage=="E1"){
            manager.currentMessage="E2";
        }  
        else if(manager.currentMessage=="E2"){
            manager.currentMessage="E3";
        }
        else if(manager.currentMessage=="E3"){
            manager.currentMessage="Died";
        }
    }
}
