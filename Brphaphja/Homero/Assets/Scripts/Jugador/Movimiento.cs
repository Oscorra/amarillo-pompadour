using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientodelante : MonoBehaviour
{
    Animator anim;
    private Dinamica Dinamica;
    void Start()
    {
        anim = GetComponent<Animator>();
        Dinamica = GetComponent<Dinamica>();
    }

    
    void Update()
    {
        anim.SetFloat("VelZ", Dinamica.inputZ);
        anim.SetFloat("VelX", Dinamica.inputX);
    }
}
