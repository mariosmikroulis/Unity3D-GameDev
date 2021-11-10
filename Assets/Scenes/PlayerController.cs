using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    Vector2 mouseMovement;

    void OnMove(InputValue value) {
    	moveValue = value.Get<Vector2>();
    	Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate(){
         Vector3 facingDirection = transform.forward;
    	// Vector3 movement = new Vector3(moveValue.x * speed, 0.0f, moveValue.y * speed);
        Vector3 movement = new Vector3(facingDirection.x * speed, 0.0f, facingDirection.z * speed);
    	Vector3 newPos = (GetComponent<Rigidbody>().position + movement);
    	GetComponent<Rigidbody>().position = newPos;
   
    	mouseMovement.x += Input.GetAxis("Mouse X")*12;
        mouseMovement.y += Input.GetAxis("Mouse Y")*12;
        transform.localRotation = Quaternion.Euler(0, mouseMovement.x,0);
    }
}
