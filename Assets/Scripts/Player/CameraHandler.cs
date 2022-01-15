using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private static CameraHandler instance;
    public float mouseSensitivity = 300f;
    float x_rotation = 0f;

    public Transform playerBody;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    
    // Handles camera movement
    void Update()
    {
        float x_mouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y_mouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        x_rotation -= y_mouse;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * x_mouse);
    }

    // Gets instance of CameraHandler
    public static CameraHandler getInstance() {
        return instance;
    }

    // Gets mouse sensitivity
    public float getMouseSensitivity() {
        return mouseSensitivity;
    }

    // Sets mouse sensitivity
    public void setMouseSensitivity(float amount) {
        if(amount < 1) {
            amount = 1;
        } else if(amount > 1000) {
            amount = 1000;
        }

        mouseSensitivity = amount;
    }
}
 