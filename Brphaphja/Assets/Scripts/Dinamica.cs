using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamica : MonoBehaviour
{
    private MeshRenderer m_Renderer_Jugador;
    private Rigidbody rb_Jugador;
    private float coordenadaX, coordenadaY, coordenadaZ;
    public float multiplicadorDesplazamiento = 8.0f;
    private Vector3 velocidad_i;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer_Jugador = GetComponent<MeshRenderer>();
        rb_Jugador = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_Renderer_Jugador.enabled = true;
        //rb_Jugador.useGravity = true;

        coordenadaY = rb_Jugador.velocity.y;
        coordenadaX = Input.GetAxis("Horizontal") * multiplicadorDesplazamiento;
        coordenadaZ = Input.GetAxis("Vertical") * multiplicadorDesplazamiento;

        velocidad_i = new Vector3(coordenadaX, coordenadaY, coordenadaZ);
        rb_Jugador.velocity = velocidad_i;
    }
}
