using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour
{
    public Text actionText;

    private bool isInArea = false;
    private bool hasAxe = false;
    private bool isMining = false;


    // ----------------------------------------------
    // Generic things.
    // ----------------------------------------------
    protected string materialName = "unknown";
    protected float respawnTime = 60.0f;


    // ----------------------------------------------
    // Pickup Rates
    // ----------------------------------------------
    protected float easyPickupTime = 1.0f;
    protected float mediumPickupTime = 2.0f;
    protected float hardPickupTime = 4.0f;

    // ----------------------------------------------
    // Drop Rates
    // ----------------------------------------------
    // Easy
    protected int minDropEasy = 3;
    protected int maxDropEasy = 6;

    // Medium
    protected int minDropMedium = 2;
    protected int maxDropMedium = 4;

    // Hard level.
    protected int minDropHard = 1;
    protected int maxDropHard = 2;

    // Update is called once per frame
    void Update()
    {
        if(isInArea && hasAxe && !isMining && Input.GetKeyUp(KeyCode.F)) {
            StartCoroutine(pickup());
        }
    }
    

    // has our player exited our collider?
    private void OnTriggerEnter(Collider other) {
        // Is our collider a player?
        if(!other.CompareTag("Player")) {
            return;
        }
        
        isInArea = true;

        hasAxe = Generic.getInventory().hasItem("axe", 1);
        InventoryItem item = Generic.getInventory().getItem(materialName);

        if(hasAxe)
            actionText.text = "PRESS [F] TO MINE " + item.getName().ToUpper() + ".";
        else
            actionText.text = "YOU NEED A MINING AXE TO MINE THE " + item.getName().ToUpper() + " MATERIAL. TRY TO FIND IT SOMEWHERE!";

        actionText.enabled = true;
    }

    
    // has our player exited our collider?
    private void OnTriggerExit(Collider other) {
        // Is our collider a player?
        if(!other.CompareTag("Player")) {
            return;
        }

        // hide the text and set the script that the player is out of the area
        isInArea = false;
        actionText.enabled = false;
    }

    // Quick thread creator to detect the reset of the pickup time.
    private IEnumerator pickup() {
        isMining = true;

        actionText.text = "YOU ARE MINING...";

        // Delays depending on the difficulty level.
        if(Generic.difficultyLevelSet == 0) {
            yield return new WaitForSeconds(easyPickupTime);
        }

        else if(Generic.difficultyLevelSet == 1) {
            yield return new WaitForSeconds(mediumPickupTime);
        }

        else if(Generic.difficultyLevelSet == 2) {
            yield return new WaitForSeconds(hardPickupTime);
        }

        // Give the necessary reward if the player is still in the area
        if(isInArea) {
            StartCoroutine(reward());
            // Hide the game object so we can hide it below for a few seconds.
            gameObject.transform.parent.gameObject.transform.Find("Model").gameObject.SetActive(false);
            // delay certain seconds
            yield return new WaitForSeconds(respawnTime);

            // reappear the stone.
            gameObject.transform.parent.gameObject.transform.Find("Model").gameObject.SetActive(true);
        }

        isMining = false;
    }

    protected IEnumerator reward() {
        int amount = 1;

        // set the amount that the player should be rewarded based on the chosen level
        if(Generic.difficultyLevelSet == 0)
            amount = Random.Range(minDropEasy, maxDropEasy);
        
        else if(Generic.difficultyLevelSet == 1)
            amount = Random.Range(minDropMedium, maxDropMedium);
        
        else if(Generic.difficultyLevelSet == 2)
            amount = Random.Range(minDropHard, maxDropHard);
        
        // give the item to the player.
        Generic.getInventory().addItem(materialName, amount);
        string txt = "YOU MINED " + amount + " " + Generic.getInventory().getItem(materialName).getName().ToUpper() + ".";

        actionText.text = txt;

        // Wait for a few seconds while showing what item the item mined and the amount.
        yield return new WaitForSeconds(5.0f);

        // hide the text, if it is still the same, and hasn't changed.
        if(actionText.text == txt) {
            actionText.text = "";
            actionText.enabled = false;
        }
    }
}
