using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float lookSensitivity = 100f;

    [SerializeField]
    private Transform playerObj;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse movement side to side (X value) and forward and backward (Y value)
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        //the camera movement up and down will be done about the x axis
        //it will also stop the camera from rotating more than 90 degrees up or down
        //so that the camera is bound by similar look rules as people
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //will rotate the camera up and down based on the previous bit
        //side to side looking will just rotate whole player object
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerObj.Rotate(Vector3.up * mouseX);
    }
}
