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
        if (Input.GetKeyDown(KeyCode.H))
            anim.SetBool("homerodaleduro", true);

        if (Input.GetKeyUp(KeyCode.H))
            anim.SetBool("homerodaleduro", false);
    }

}