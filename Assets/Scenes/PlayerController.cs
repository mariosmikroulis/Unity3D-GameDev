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

    bool issue1Fixer = false;
    bool issue2Fixer = false;

    bool oxygenArea = false;
    bool issue1Area = false;
    bool issue2Area = false;
    bool doorArea = false;

    bool touchingFloor = true;

    public Text oxygenText;
    public OxygenController oxygenController;

    public Text announcementsText;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
            announcementsText.text = "Press F to get Oxygen";
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = true;
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = true;
        }
        if(other.gameObject.tag == "Door"){
            doorArea = true;
            announcementsText.text = "Press F to go outside";
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
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = false;
        }
        if(other.gameObject.tag == "Door"){
            doorArea = false;
            announcementsText.text = "";
        }
    }

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
                transform.position = new Vector3(2.5f, 14, 36);
                doorArea = false;
            }
            if(oxygenArea){
                oxygenText.text = "Oxygen: 100";
                oxygenController.timer = 10.0f;
            }
            if(issue1Area){
                if(issue1Fixer){

                }else{

                }
            }
            if(issue2Area){
                if(issue2Fixer){

                }else{

                }
            }
        }
   
    	mouseMovement.x += Input.GetAxis("Mouse X")*350;
        transform.localRotation = Quaternion.Euler(0, mouseMovement.x*Time.deltaTime,0);
    }
}
