using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotacionCamara : MonoBehaviour
{
    [Header("Sensibilidad")]
    public float sensibilidadX = 200f;
    public float sensibilidadY = 150f;

    [Header("Límites verticales")]
    public float minY = -20f;
    public float maxY = 60f;

    [Header("Distancia y objetivo")]
    public Transform objetivo;   // El objeto dentro del jugador
    public float distancia = 5f;
    public float altura = 2f;

    private float rotX;
    private float rotY;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotX = angles.y;
        rotY = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        // Movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadY * Time.deltaTime;

        rotX += mouseX;
        rotY -= mouseY;

        rotY = Mathf.Clamp(rotY, minY, maxY);

        // Rotación final
        Quaternion rot = Quaternion.Euler(rotY, rotX, 0f);

        // Posición de la cámara alrededor del objetivo
        Vector3 offset = rot * new Vector3(0, altura, -distancia);

        transform.position = objetivo.position + offset;

        // Mirar al objetivo
        transform.LookAt(objetivo);
    }

}
