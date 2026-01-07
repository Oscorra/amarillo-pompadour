using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager thisInstance;

    void Awake()
    {
        if (thisInstance == null)
        {

            thisInstance = this;

            DontDestroyOnLoad(thisInstance);
        }
        else
        {
            Destroy(this.gameObject);   
        }
    }
}
