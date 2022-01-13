using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    Vector2 mouseMovement;

    bool oxygenArea = false;
    bool issue1Area = false;
    bool issue2Area = false;
    bool issue3Area = false;
    bool issueSilver = false;
    bool issueGold = false;
    bool doorArea = false;
    bool doorAreaOutside = false;

    bool touchingFloor = true;

    public PlayerManagement playerManagement;

    public Material green;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    // All areas which thee playe can inteact with
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to get Oxygen");
        }
        if(other.gameObject.tag == "Issue1"){
            if(Generic.fuelCompleted) return;
            issue1Area = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to add Fuel (20)");
        }
        if(other.gameObject.tag == "Issue2"){
            if(Generic.chipCompleted) return;
            issue2Area = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to replace the Chip");
        }
        if(other.gameObject.tag == "Issue3"){
            if(Generic.pumpCompleted) return;
            issue3Area = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to replace the Pump");
        }
        if(other.gameObject.tag == "IssueGold"){
            if(Generic.goldCompleted) return;
            issueGold = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to add Gold (10)");
        }
        if(other.gameObject.tag == "IssueSilver"){
            if(Generic.silverCompleted) return;
            issueSilver = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to add Silver (15)");
        }
        if(other.gameObject.tag == "Door"){
            doorArea = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to go outside");
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = true;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to go in the ship");
        }

    }

    void OnCollisionStay(Collision info){
        
    }
    
    void OnCollisionExit(){
        touchingFloor = false;
    }


    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "Issue3"){
            issue3Area = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "IssueGold"){
            issueGold = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "IssueSilver"){
            issue3Area = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "Door"){
            doorArea = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = false;
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
        if(other.gameObject.tag == "Disabled"){
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
        }
    }

    // Player Movement and Interactions
    void FixedUpdate(){

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 forwardDir = new Vector3(forward.x, 0, forward.z).normalized;
        Vector3 rightDir = new Vector3(right.x, 0, right.z).normalized;
        Vector3 upDir = new Vector3(0, 1, 0).normalized;


        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().AddForce(forwardDir * 650f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(rightDir * -450f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().AddForce(forwardDir * -450f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(rightDir * 450f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {
            if(!touchingFloor) return;
            GetComponent<Rigidbody>().AddForce(upDir * 5000f * Time.deltaTime,
                 ForceMode.Impulse);
        }
        if (Input.GetKey("f"))
        {
            if(doorArea){
                transform.position = new Vector3(-2f, 14, 36);
                doorArea = false;
                Generic.setLocationArea(LocationArea.World);
            }
            if(doorAreaOutside){
                transform.position = new Vector3(193.9f, 2.4f, 0.14f);
                doorAreaOutside = false;
                Generic.setLocationArea(LocationArea.MainShip);
            }
            if(oxygenArea){
                Generic.setOxygen(100);
            }
            if(issue1Area){
                if(Generic.fuel>=20){
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You added Fuel to the ship.");
                    GameObject.FindWithTag("Issue1").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.fuelCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You don't have enough Fuel (20)");
                }
            }
            if(issue2Area){
                if(Generic.hasChip){
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You replaced the broken Chip");
                    GameObject.FindWithTag("Issue2").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.chipCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You need a Chip to place here");
                }
            }
            if(issueGold){
                if(Generic.gold >= 10){
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You added the required gold");
                    GameObject.FindWithTag("IssueGold").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.goldCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You don't have enough Gold (10)");
                }
            }
            if(issueSilver){
                if(Generic.silver >= 15){
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You added the required silver");
                    GameObject.FindWithTag("IssueSilver").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.silverCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You don't have enough Silver (15)");
                }
            }
            if(issue3Area){
                if(Generic.hasPump){
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You replaced the broken Pump");
                    GameObject.FindWithTag("Issue3").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.pumpCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You need a Pump to place here");
                }
            }
            if(Generic.pumpCompleted && Generic.chipCompleted && Generic.fuelCompleted && Generic.goldCompleted && Generic.silverCompleted){
                GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("playerWonGame");
            }
        }
   
    	mouseMovement.x += Input.GetAxis("Mouse X")*350;
        transform.localRotation = Quaternion.Euler(0, mouseMovement.x*Time.deltaTime,0);
    }
}
