using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class OxygenController : MonoBehaviour
{
    public float timer = 4.0f;
    public Text oxygenText;

    void Start()
    {
        oxygenText.text = "Oxygen: 100";
    }

    void Update(){
        if(Generic.oxygenLevel <= 0){
            //Lose
        }
        timer -= Time.deltaTime;
        if(timer<=0){
            Generic.oxygenLevel -=1;
            oxygenText.text = "Oxygen: " + Generic.oxygenLevel;
            timer = 4.0f;
        }
    }
}
