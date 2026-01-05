using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("cmueve", true);
        }
        if (!Input.GetKey("w"))
        {
            anim.SetBool("cmueve", false);
        }
    }
}
