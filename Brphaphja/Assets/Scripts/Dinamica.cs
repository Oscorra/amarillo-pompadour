using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamica : MonoBehaviour
{
    private MeshRenderer m_Renderer_Jugador;
    private Rigidbody rb_Jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer_Jugador = GetComponent<MeshRenderer>();
        rb_Jugador = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Renderer_Jugador.enabled = true;
        rb_Jugador.useGravity = true;
    }
}
