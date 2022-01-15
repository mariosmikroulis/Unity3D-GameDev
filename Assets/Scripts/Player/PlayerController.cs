using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool oxygenArea = false;
    bool issue1Area = false;
    bool issue2Area = false;
    bool issue3Area = false;
    bool issueSilver = false;
    bool issueGold = false;
    bool doorArea = false;
    bool doorAreaOutside = false;
    bool ship2Entrance = false;
    bool ship2Exit = false;

    bool ship2Chip = false;
    bool ship2Fuel = false;
    bool ship2Start = false;

    public Material green;

    // All areas which thee playe can inteact with
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
            Menus.getInstance().setAnnouncementText("Press [F] to get Oxygen");
        }
        if(other.gameObject.tag == "Issue1"){
            if(Generic.fuelCompleted) return;
            issue1Area = true;
            Menus.getInstance().setAnnouncementText("Press [F] to add Fuel (20)");
        }
        if(other.gameObject.tag == "Issue2"){
            if(Generic.chipCompleted) return;
            issue2Area = true;
            Menus.getInstance().setAnnouncementText("Press [F] to replace the Chip");
        }
        if(other.gameObject.tag == "Issue3"){
            if(Generic.pumpCompleted) return;
            issue3Area = true;
            Menus.getInstance().setAnnouncementText("Press [F] to replace the Pump");
        }
        if(other.gameObject.tag == "Door"){
            doorArea = true;
            Menus.getInstance().setAnnouncementText("Press [F] to go outside");
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = true;
            Menus.getInstance().setAnnouncementText("Press [F] to go in the ship");
        }
        if(other.gameObject.tag == "Ship2Entrance"){
            ship2Entrance = true;
            Menus.getInstance().setAnnouncementText("Press [F] to go in the ship");
        }
        if(other.gameObject.tag == "Ship2Exit"){
            ship2Exit = true;
            Menus.getInstance().setAnnouncementText("Press [F] to go in the ship");
        }
        if(other.gameObject.tag == "Ship2Chip"){
            if(Generic.chip2Completed) return;
            ship2Chip = true;
            Menus.getInstance().setAnnouncementText("Press [F] to replace the Chip");
        }
        if(other.gameObject.tag == "Ship2Fuel"){
            if(Generic.fuel2Completed) return;
            ship2Fuel = true;
            Menus.getInstance().setAnnouncementText("Press [F] to add Fuel (20)");
        }
        if(other.gameObject.tag == "Ship2Start"){
            ship2Start = true;
            Menus.getInstance().setAnnouncementText("Press [F] to start the ship");
        }

    }


    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Issue3"){
            issue3Area = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "IssueGold"){
            issueGold = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "IssueSilver"){
            issue3Area = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Door"){
            doorArea = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Disabled"){
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Ship2Entrance"){
            ship2Entrance = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Ship2Exit"){
            ship2Exit = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Ship2Chip"){
            ship2Chip = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Ship2Fuel"){
            ship2Fuel = false;
            Menus.getInstance().setAnnouncementText("");
        }
        if(other.gameObject.tag == "Ship2Start"){
            ship2Start = false;
            Menus.getInstance().setAnnouncementText("");
        }

    }

    // Player Movement and Interactions
    void FixedUpdate(){
        if (Input.GetKey("f"))
        {
            if(ship2Entrance){
                transform.position = new Vector3(183f, 2.4f, -1f);
                ship2Entrance = false;
                Generic.setLocationArea(LocationArea.World);
            }else if(ship2Exit){
                transform.position = new Vector3(10f, 14.5f,-325.45f);
                ship2Exit= false;
                Generic.setLocationArea(LocationArea.World);
            }else if(doorArea){
                transform.position = new Vector3(-9f, 14,39);
                doorArea = false;
                Generic.setLocationArea(LocationArea.World);
            }else if(doorAreaOutside){
                transform.position = new Vector3(193.9f, 2.4f, 0.14f);
                doorAreaOutside = false;
                Generic.setLocationArea(LocationArea.MainShip);
            }else if(oxygenArea){
                Generic.setOxygen(100);
            }else if(issue1Area){
                if(Generic.fuelCompleted == true) return;
                if(Generic.getInventory().hasItem("fuel", 2)){
                    Menus.getInstance().setAnnouncementText("You added Fuel to the ship.");
                    Generic.fuelCompleted = true;
                    Generic.getInventory().removeItem("fuel", 2);
                    Generic.tasksCompleted +=1;

                }else{
                    Menus.getInstance().setAnnouncementText("You don't have enough Fuel (20)");
                }
            }else if(issue2Area){
                if(Generic.chipCompleted == true) return;
                if(Generic.getInventory().hasItem("chip", 1)){
                    Menus.getInstance().setAnnouncementText("You replaced the broken Chip");
                    Generic.chipCompleted = true;
                    Generic.getInventory().removeItem("chip", 1);
                    Generic.tasksCompleted +=1;
                }else{
                    Menus.getInstance().setAnnouncementText("You need a Chip to place here");
                }
            }else if(issue3Area){
                if(Generic.pumpCompleted == true) return;
                if(Generic.getInventory().hasItem("pump", 1)){
                    Menus.getInstance().setAnnouncementText("You replaced the broken Pump");
                    Generic.pumpCompleted = true;
                    Generic.getInventory().removeItem("pump", 1);
                    Generic.tasksCompleted +=1;
                }else{
                    Menus.getInstance().setAnnouncementText("You need a Pump to place here");
                }
            }else if(ship2Chip){
                if(Generic.chip2Completed == true) return;
                if(Generic.getInventory().hasItem("chip", 1)){
                    Menus.getInstance().setAnnouncementText("You replaced the broken Chip");
                    Destroy(GameObject.FindWithTag("Ship2Chip"));
                    Generic.chip2Completed = true;
                    Generic.getInventory().removeItem("chip", 1);
                    Generic.tasks2Completed +=1;
                }else{
                    Menus.getInstance().setAnnouncementText("You need a Chip to place here");
                }
            }else if(ship2Fuel){
                if(Generic.fuel2Completed == true) return;
                if(Generic.getInventory().hasItem("fuel", 2)){
                    Menus.getInstance().setAnnouncementText("You added Fuel to the ship");
                    Destroy(GameObject.FindWithTag("Ship2Fuel"));
                    Generic.fuel2Completed = true;
                    Generic.getInventory().removeItem("fuel", 2);
                    Generic.tasks2Completed +=1;
                }else{
                    Menus.getInstance().setAnnouncementText("You don't have enough Fuel (20)");
                }
            }
            if(Generic.tasks2Completed == 2){
                GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerWonGame2");
            }
            if(Generic.tasksCompleted == 3){
                GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerWonGame");
            }
        }
    }
}
