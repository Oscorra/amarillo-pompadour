using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotacionCamara : MonoBehaviour
{


    public float sensitivity = 150f;
    float rotationX = 0f;
    float rotationY = 0f;

     void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, 30f, 80f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

    }
}
