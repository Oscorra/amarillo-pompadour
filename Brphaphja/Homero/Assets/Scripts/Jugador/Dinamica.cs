using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamica : MonoBehaviour
{
    private MeshRenderer m_Renderer_Jugador;
    private Rigidbody rb_Jugador;

    public float multiplicadorDesplazamiento = 8.0f;
    public Transform cameraTransform;
    private GameObject gameManager;
    private AudioSource eaten;
    private float inputX, inputZ;
    private Vector3 direccionMovimiento;

    void Start()
    {
        m_Renderer_Jugador = GetComponent<MeshRenderer>();
        rb_Jugador = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Bonuses(GM)");
        eaten = gameManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        direccionMovimiento = (camForward * inputZ + camRight * inputX) * multiplicadorDesplazamiento;

        direccionMovimiento.y = rb_Jugador.velocity.y;
    }

    void FixedUpdate()
    {
        rb_Jugador.velocity = direccionMovimiento;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colisionado = collision.gameObject;
        GameObject colisionante = this.gameObject;

        Debug.Log("Que rico");

        string tagColisionado = colisionado.tag;
        string tagColisionante = colisionante.tag;

        if (tagColisionado == "Eatable")
        {
            eaten.Play();
            Destroy(colisionado);   
        }
    }
}
