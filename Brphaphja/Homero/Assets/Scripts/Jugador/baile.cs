using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baile : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey("h"))
        {
            anim.SetBool("homerodaleduro", true);
        }
        if (!Input.GetKey("h"))
        {
            anim.SetBool("homerodaleduro", false);
        }
    }
}