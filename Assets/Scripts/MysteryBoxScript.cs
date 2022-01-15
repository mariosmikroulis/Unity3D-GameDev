using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBoxScript : MonoBehaviour
{
    bool active = true; //Checks if the Mystery Box is active
    bool inArea = false; //Checks if the Player is in the MysteryBoxs collider.

    public static float timer = 0.0f; //Timer used for removing the announcement.

    //Player has entered the collider
    private void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Player")) return;
        if(!active) return;
        inArea = true;

        Menus.getInstance().setAnnouncementText("Press [F] to open the box.");
    }
    //Player has left the collider
    void OnTriggerExit(Collider other){
        if(!other.CompareTag("Player")) return;
        inArea = false;
        Menus.getInstance().setAnnouncementText("");
    }


    void Update(){
        if(timer != 0.0f){
            timer -= Time.deltaTime;
        }
        if(Input.GetKey("f") && active && inArea){
            active = false;
            GiveRandomItem();
            timer = 15.0f;
        }
        if(timer<0){
            if(Menus.getInstance().getAnnouncementText() == "Press [F] to open the box.") return;
            Menus.getInstance().setAnnouncementText("");
            timer = 0.0f;
        }
    }

    //Gives the player a random item (fuel,pump,chip)
    void GiveRandomItem(){
        bool axe = false;
        if(!Generic.getInventory().hasItem("axe")){
            axe = GiveAxe();
        }
        if(axe) return;

        System.Random random = new System.Random(); 
        int rand = random.Next(1, 4);
        if(rand == 1){
            Generic.getInventory().addItem("fuel", 1);
            Menus.getInstance().setAnnouncementText("You found 10 fuel tanks.");
            return;
        }
        if(rand == 2){
            Generic.getInventory().addItem("pump", 1);
            Menus.getInstance().setAnnouncementText("You found a fuel pump.");
            return;
        }
        if(rand == 3){
            Generic.getInventory().addItem("chip", 1);
            Menus.getInstance().setAnnouncementText("You found a chip.");
            return;
        }
    }

    // Gives the axe to the player after 3 failed tries (important item)
    bool GiveAxe(){
        if(Generic.axeTries == 3){
            Generic.getInventory().addItem("axe", 1);
            Menus.getInstance().setAnnouncementText("You found an axe.");
            return true;
        }
        System.Random random = new System.Random(); 
        int rand = random.Next(1, 4);
        if(rand == 1){
            Generic.getInventory().addItem("axe", 1);
            Menus.getInstance().setAnnouncementText("You found an axe.");
            return true;
        }
        Generic.axeTries+=1;
        return false;
    }
}
