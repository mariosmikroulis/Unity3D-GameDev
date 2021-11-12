using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBoxScript : MonoBehaviour
{
    bool active = true; //Checks if the Mystery Box is active
    bool inArea = false; //Checks if the Player is in the MysteryBoxs collider.

	public Text announcementsText; //Text in the center of the sceen

    public float timer = 0.0f; //Timer used for removing the announcement.

    //Player has entered the collider
    private void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Player")) return;
        if(!active) return;
        inArea = true;
        announcementsText.text = "Press F to open the box";
    }
    //Player has left the collider
    void OnTriggerExit(Collider other){
        if(!other.CompareTag("Player")) return;
        inArea = false;
        if(announcementsText.text == "Press F to open the box"){
            announcementsText.text = "";
        }
    }


    void Update(){
        if(timer != 0.0f){
            timer -= Time.deltaTime;
        }
        if(Input.GetKey("f") && active && inArea){
            active = false;
            Debug.Log("+");
            GiveRandomItem();
            timer = 3.0f;
        }
        if(timer<0){
            if(announcementsText.text == "Press F to open the box") return;
            announcementsText.text = "";
            timer = 0.0f;
        }
    }

    //Gives the player a random item (fuel,pump,chip)
    void GiveRandomItem(){
        bool hasAxe = false;
        bool axe = false;
        if(!Generic.hasAxe){
            axe = GiveAxe();
        }
        if(axe) return;

        System.Random random = new System.Random(); 
        int rand = random.Next(1, 4);
        if(rand == 1){
            Generic.getInventory().addItem("fuel", 1);
            announcementsText.text = "You found 10 litres of rocket fuel!";
            return;
        }
        if(rand == 2){
            Generic.getInventory().addItem("pump", 1);
            announcementsText.text = "You found a fuel pump!";
            return;
        }
        if(rand == 3){
            Generic.getInventory().addItem("chip", 1);
            announcementsText.text = "You found a chip!";
            return;
        }
    }

    bool GiveAxe(){
        if(Generic.axeTries == 3){
            Generic.getInventory().addItem("axe", 1);
            announcementsText.text = "You found an axe!";
            Generic.hasAxe = true;
            return true;
        }
        System.Random random = new System.Random(); 
        int rand = random.Next(1, 4);
        if(rand == 1){
            Generic.getInventory().addItem("axe", 1);
            announcementsText.text = "You found an axe!";
            Generic.hasAxe = true;
            return true;
        }
        Generic.axeTries+=1;
        return false;
    }
}
