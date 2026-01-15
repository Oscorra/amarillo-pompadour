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
    private Animator homeroMuevete;
    public float inputX { get; private set; }
    public float inputZ { get; private set; }
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

        direccionMovimiento = (camForward * inputZ + camRight * inputX);
    }

    void FixedUpdate()
    {
        if (direccionMovimiento.sqrMagnitude > 0.1)
        {
            direccionMovimiento.Normalize();
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMovimiento, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, 0.2f);

            Vector3 direccion = rb_Jugador.position + direccionMovimiento * multiplicadorDesplazamiento * Time.fixedDeltaTime;
            rb_Jugador.MovePosition(direccion);
        }

        Vector3 movimientoLocal = transform.InverseTransformDirection(direccionMovimiento);

        if (homeroMuevete != null)
        {
            homeroMuevete.SetFloat("VelZ", movimientoLocal.z);
            homeroMuevete.SetFloat("VelX", movimientoLocal.x);
        }
    }

    /*private void OnTriggerEnter(Collision collision)
    {
        GameObject colisionado = collision.gameObject;
        GameObject colisionante = this.gameObject;

        

        string tagColisionado = colisionado.tag;
        string tagColisionante = colisionante.tag;

        if (tagColisionado == "Eatable")
        {
            eaten.Play();
            Debug.Log("Que rico");
            Destroy(colisionado);   
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        GameObject colisionado = other.gameObject;
        GameObject colisionante = this.gameObject;



        string tagColisionado = colisionado.tag;
        string tagColisionante = colisionante.tag;

        if (tagColisionado == "Eatable")
        {
            eaten.Play();
            Debug.Log("Que rico");
            Destroy(colisionado);
        }
    }
}
