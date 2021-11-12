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

    public Text oxygenText;
    public OxygenController oxygenController;

    public Text announcementsText;

    public Material orange;
    public Material green;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    // All areas which thee playe can inteact with
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
            announcementsText.text = "Press F to get Oxygen";
        }
        if(other.gameObject.tag == "Issue1"){
            if(Generic.fuelCompleted) return;
            issue1Area = true;
            announcementsText.text = "Press F to add Fuel (20)";
        }
        if(other.gameObject.tag == "Issue2"){
            if(Generic.chipCompleted) return;
            issue2Area = true;
            announcementsText.text = "Press F to replace the Chip";
        }
        if(other.gameObject.tag == "Issue3"){
            if(Generic.pumpCompleted) return;
            issue3Area = true;
            announcementsText.text = "Press F to replace the Pump";
        }
        if(other.gameObject.tag == "IssueGold"){
            if(Generic.goldCompleted) return;
            issueGold = true;
            announcementsText.text = "Press F to add Gold (10)";
        }
        if(other.gameObject.tag == "IssueSilver"){
            if(Generic.silverCompleted) return;
            issueSilver = true;
            announcementsText.text = "Press F to add Silver (15)";
        }
        if(other.gameObject.tag == "Door"){
            doorArea = true;
            announcementsText.text = "Press F to go outside";
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = true;
            announcementsText.text = "Press F to go in the ship";
        }

    }

    void OnCollisionStay(){
        touchingFloor = true;
    }
    
    void OnCollisionExit(){
        touchingFloor = false;
    }


    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "Issue3"){
            issue3Area = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "IssueGold"){
            issueGold = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "IssueSilver"){
            issue3Area = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "Door"){
            doorArea = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "DoorOutside"){
            doorAreaOutside = false;
            announcementsText.text = "";
        }
        if(other.gameObject.tag == "Disabled"){
            announcementsText.text = "";
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
            GetComponent<Rigidbody>().AddForce(forwardDir * 350f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(rightDir * -250f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().AddForce(forwardDir * -250f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(rightDir * 250f * Time.deltaTime,
                 ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {
            if(!touchingFloor) return;
            GetComponent<Rigidbody>().AddForce(upDir * 1500f * Time.deltaTime,
                 ForceMode.Impulse);
        }
        if (Input.GetKey("f"))
        {
            if(doorArea){
                transform.position = new Vector3(-2f, 14, 36);
                doorArea = false;
            }
            if(doorAreaOutside){
                transform.position = new Vector3(193.9f, 2.4f, 0.14f);
                doorArea = false;
            }
            if(oxygenArea){
                oxygenText.text = "Oxygen: 100";
                oxygenController.timer = 10.0f;
            }
            if(issue1Area){
                if(Generic.fuel>=20){
                    announcementsText.text = "You added Fuel to the ship.";
                    GameObject.FindWithTag("Issue1").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.fuelCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    announcementsText.text = "You don't have enough Fuel (20)";
                }
            }
            if(issue2Area){
                if(Generic.hasChip){
                    announcementsText.text = "You replaced the broken Chip";
                    GameObject.FindWithTag("Issue2").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.chipCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    announcementsText.text = "You need a Chip to place here";
                }
            }
            if(issueGold){
                if(Generic.gold >= 10){
                    announcementsText.text = "You added the required gold";
                    GameObject.FindWithTag("IssueGold").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.goldCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    announcementsText.text = "You don't have enough Gold (10)";
                }
            }
            if(issueSilver){
                if(Generic.silver >= 15){
                    announcementsText.text = "You added the required silver";
                    GameObject.FindWithTag("IssueSilver").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.silverCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    announcementsText.text = "You don't have enough Silver (15)";
                }
            }
            if(issue3Area){
                if(Generic.hasPump){
                    announcementsText.text = "You replaced the broken Pump";
                    GameObject.FindWithTag("Issue3").transform.parent.gameObject.GetComponent<MeshRenderer>().material = green;
                    Generic.pumpCompleted = true;
                    Generic.tasksCompleted +=1;
                }else{
                    announcementsText.text = "You need a Pump to place here";
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
