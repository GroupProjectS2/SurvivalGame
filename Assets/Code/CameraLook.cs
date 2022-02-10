using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //mouse sensivity variable
    public float mouseSens = 100f;

    //do not change unless needed
    [Header("Unchanged values")]
    float xRotation = 0f;
    public Transform pMain;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //gets mouse look value
        float mouseX = Input.GetAxis("Mouse X") * mouseSens ;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens ;

        //locks the look rotation for up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //this rotates the player depending on where they are looking
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        pMain.Rotate(Vector3.up * mouseX);
    }
}
