using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    Vector2 mouseMovement;
    bool oxygenArea = false;
    public Text oxygenText;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Oxygen"){
            oxygenArea = false;
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
            if(oxygenArea){
                oxygenText.text = "Oxygen: 100";
            }
        }
   
    	mouseMovement.x += Input.GetAxis("Mouse X")*220;
        mouseMovement.y += Input.GetAxis("Mouse Y")*12;
        transform.localRotation = Quaternion.Euler(0, mouseMovement.x*Time.deltaTime,0);
    }
}
