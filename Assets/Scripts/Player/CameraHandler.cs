using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    float x_rotation = 0f;

    public Transform playerBody;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
 
    void Update()
    {
        float x_mouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y_mouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        x_rotation -= y_mouse;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        // playerBody.Rotate(Vector3.up * x_mouse);
    }
}
 