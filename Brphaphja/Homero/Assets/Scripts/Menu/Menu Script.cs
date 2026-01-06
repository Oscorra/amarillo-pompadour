using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void EmpezarNivel (string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se esta cerrando...");
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
