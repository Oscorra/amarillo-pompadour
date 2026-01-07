using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoatras : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey("s"))
        {
            ani.SetBool("cmueveatras", true);
        }
        if (!Input.GetKey("s"))
        {
            ani.SetBool("cmueveatras", false);
        }
    }
}