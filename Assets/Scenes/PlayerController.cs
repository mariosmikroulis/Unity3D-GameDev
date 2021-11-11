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

    public Text oxygenText;
    public OxygenController controller;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = true;
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = true;
        }
        if(other.gameObject.tag == "Door"){
            doorArea = true;
        }

    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = false;
        }
        if(other.gameObject.tag == "Issue1"){
            issue1Area = false;
        }
        if(other.gameObject.tag == "Issue2"){
            issue2Area = false;
        }
        if(other.gameObject.tag == "Door"){
            doorArea = false;
        }
    }

    void FixedUpdate(){
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 forwardDir = new Vector3(forward.x, 0, forward.z).normalized;
        Vector3 rightDir = new Vector3(right.x, 0, right.z).normalized;

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
        if (Input.GetKey("f"))
        {
            if(doorArea){
                SceneManager.LoadScene("SceneOutside", LoadSceneMode.Additive);
                doorArea = false;
            }
            if(oxygenArea){
                oxygenText.text = "Oxygen: 100";
                controller.timer = 10.0f;
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
   
    	mouseMovement.x += Input.GetAxis("Mouse X")*220;
        mouseMovement.y += Input.GetAxis("Mouse Y")*12;
        transform.localRotation = Quaternion.Euler(0, mouseMovement.x*Time.deltaTime,0);
    }
}
