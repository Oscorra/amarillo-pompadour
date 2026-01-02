using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamica : MonoBehaviour
{
    private MeshRenderer m_Renderer_Jugador;
    private Rigidbody rb_Jugador;

    public float multiplicadorDesplazamiento = 8.0f;
    public Transform cameraTransform; // Asigna el CameraTarget o la cámara

    private float inputX, inputZ;
    private Vector3 direccionMovimiento;

    void Start()
    {
        m_Renderer_Jugador = GetComponent<MeshRenderer>();
        rb_Jugador = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        // Direcciones de la cámara en el plano XZ
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // Dirección final del movimiento relativa a la cámara
        direccionMovimiento = (camForward * inputZ + camRight * inputX) * multiplicadorDesplazamiento;

        // Mantener la velocidad vertical del rigidbody
        direccionMovimiento.y = rb_Jugador.velocity.y;
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        rb_Jugador.velocity = direccionMovimiento;
    }
}
