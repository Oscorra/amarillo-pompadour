using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BotonNivel : MonoBehaviour
{
    public int numeroNivel;
    public Button boton;

    private string saveFilePath;
    private const int NIVEL_MAXIMO = 5;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/Guardado.txt";

        int nivelDesbloqueado = int.Parse(File.ReadAllText(saveFilePath));

        if (nivelDesbloqueado > NIVEL_MAXIMO)
            nivelDesbloqueado = NIVEL_MAXIMO;

        if (numeroNivel > NIVEL_MAXIMO)
        {
            boton.interactable = false;
            return;
        }

        boton.interactable = numeroNivel <= nivelDesbloqueado;
    }

    public void CargarNivel()
    {
        if (numeroNivel <= NIVEL_MAXIMO)
            SceneManager.LoadScene("Nivel" + numeroNivel);
    }
}


