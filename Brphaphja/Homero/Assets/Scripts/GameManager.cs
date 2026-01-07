using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int nivel;
    private string nombreNivel;
    private GameObject miGestor, miJugador;
    
    // Start is called before the first frame update
    void Start()
    {
        nombreNivel = SceneManager.GetActiveScene().name;
        nivel = SceneManager.GetActiveScene().buildIndex;
        miGestor = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       int numBonus = miGestor.transform.childCount;

        if (numBonus == 0)
        {
            if (nivel == 1)
            {
                SceneManager.LoadScene(2);
            }

            if (nivel == 2)
            {
                SceneManager.LoadScene(3);
            }

            if (nivel == 3)
            {
                SceneManager.LoadScene(4);
            }

            if (nivel == 4)
            {
                SceneManager.LoadScene(5);
            }

            if (nivel == 5)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
