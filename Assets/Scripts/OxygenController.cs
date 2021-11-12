using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class OxygenController : MonoBehaviour
{
    public float timer = 3.0f;
    public Text oxygenText;

    void Start()
    {
        oxygenText.text = "Oxygen: 100";
    }

    // Controlls oxygen level and ends game when its 0
    void Update(){
        if(Generic.oxygenLevel <= 0){
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerLostGame");
        }
        timer -= Time.deltaTime;
        if(timer<=0){
            Generic.oxygenLevel -= 1;
            oxygenText.text = "Oxygen: " + Generic.oxygenLevel;
            timer = 3.0f;
        }
    }
}
