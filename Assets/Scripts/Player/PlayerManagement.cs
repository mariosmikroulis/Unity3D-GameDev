using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    private float timer = 1.0f;
    public float healthRegeneration = 22f;
    public float staminaRegeneration = 0.5f;
    public bool recoverStamina = false;
    private static PlayerManagement instance;

    private bool runningStatus = false;


    private void Awake() {
        instance = this;
    }

    public static PlayerManagement getInstance() {
        return instance;
    }

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

    // Sets run status to true when player is running
    public bool setRunningStatus(bool status)
    {
        bool old = runningStatus;
        runningStatus = status;
        return old;
    }

    // Gets running status of player
    public bool getRunningStatus()
    {
        return runningStatus;
    }

    // Checks if player is recovering stamina
    public bool isRecoveryingStamina() {
        return recoverStamina;
    }

    // Controls the oxygen, stamina
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

        if(Generic.getStamina() > 10) {
            recoverStamina = false;
        } else if(Generic.getStamina() < 5) {
            recoverStamina = true;
        }
    }
}
