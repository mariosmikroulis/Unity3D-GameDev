using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class PlayerManagement : MonoBehaviour
{
    public float timer = 1.0f;
    public float healthRegeneration = 22f;
    public float staminaRegeneration = 0.5f;

    private bool runningStatus = false;

    // Controlls oxygen level and ends game when its 0
    void Update(){
        if(Generic.getOxygen() <= 0 || Generic.getHealth() <= 0) {
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerLostGame");
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0){
            runTasks();
            timer = 1.0f;
        }
    }

    public bool setRunningStatus(bool status)
    {
        bool old = runningStatus;
        runningStatus = status;
        return old;
    }

    public bool getRunningStatus()
    {
        return runningStatus;
    }

    void runTasks()
    {
        if (Generic.getLocationArea() != LocationArea.MainShip)
        {
            Generic.reduceOxygen(0.3f);
        }

        Generic.addHealth(healthRegeneration);

        if (!runningStatus) {
            Generic.addStamina(staminaRegeneration);
        }
    }
}
