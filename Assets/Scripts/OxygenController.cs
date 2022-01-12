using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class OxygenController : MonoBehaviour
{
    public float timer = 3.0f;

    // Controlls oxygen level and ends game when its 0
    void Update(){
        if(Generic.oxygenLevel <= 0){
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerLostGame");
        }

        timer -= Time.deltaTime;

        if(timer <= 0){
            if(Generic.getLocationArea() == LocationArea.World) {
                Generic.reduceOxygen(1f);
            }

            timer = 3.0f;
        }
    }
}
