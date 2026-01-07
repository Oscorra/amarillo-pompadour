using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private int nivel;
    private string saveFilePath;
    private GameObject miGestor;

    private const int NIVEL_MAXIMO = 5;

    void Start()
    {
        nivel = SceneManager.GetActiveScene().buildIndex;
        miGestor = this.gameObject;

        saveFilePath = Application.persistentDataPath + "/Guardado.txt";

        if (!File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, "1");
        }
    }

    void Update()
    {
        int numBonus = miGestor.transform.childCount;

        if (numBonus == 0)
        {
            int siguienteNivel = nivel + 1;

            // Si ya estamos en el último nivel, volvemos al menú
            if (siguienteNivel > NIVEL_MAXIMO)
            {
                SceneManager.LoadScene(0);
                return;
            }

            GuardarProgreso(siguienteNivel);
            CargarSiguienteNivel();
        }
    }

    private void GuardarProgreso(int siguienteNivel)
    {
        if (siguienteNivel > NIVEL_MAXIMO)
            siguienteNivel = NIVEL_MAXIMO;

        File.WriteAllText(saveFilePath, siguienteNivel.ToString());
        Debug.Log("Progreso guardado: Nivel " + siguienteNivel);
    }

    private void CargarSiguienteNivel()
    {
        int siguienteNivel = nivel + 1;

        if (siguienteNivel > NIVEL_MAXIMO)
            siguienteNivel = 0; // Menú

        SceneManager.LoadScene(siguienteNivel);
    }
}


